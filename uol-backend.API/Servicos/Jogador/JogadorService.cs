using System.Diagnostics.CodeAnalysis;
using uol_backend.API.Infraestrutura.BancoDeDados;
using uol_backend.API.Infraestrutura.Repositorio;
using uol_backend.API.Servicos.Base;
using uol_backend.API.Servicos.Factory;
using uol_backend.API.Servicos.Mapper;
using uol_backend.DOMAIN.Base;
using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Enumeradores;

namespace uol_backend.API.Servicos.Jogador
{
    public class JogadorService : BaseService, IJogadorService
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;
        private readonly LeitorArquivosFactory _leitorArquivosFactory;

        public JogadorService(
            BancoDataContext dataContext,
            IJogadorRepositorio jogadorRepositorio,
            LeitorArquivosFactory leitorArquivosFactory) : base(dataContext)
        {
            _jogadorRepositorio = jogadorRepositorio;
            _leitorArquivosFactory = leitorArquivosFactory;
        }

        public async Task Add(JogadorDTO dTO)
        {
            var leitor = _leitorArquivosFactory.ObterLeitor(dTO.Grupo);
            var herois = await leitor.LerArquivo();

            var codinomesJaUsados = await _jogadorRepositorio.GetDisponibleCodinames(herois);
            var heroisDisponiveis = RemoverCodinomesDuplicados(codinomesJaUsados, herois);

            var codinomeSorteado = ObterCodiNome(heroisDisponiveis.Select(x => x.Codinome).ToList());
            var jogador = JogadorMapper.ConverterParaEntidade(dTO).VincularCodinome(codinomeSorteado);

            _jogadorRepositorio.Add(jogador);

            await CommitAsync();
        }

        public bool Delete(int jogadorId)
        {
            var isSuccess = _jogadorRepositorio.Delete(jogadorId);

            if(isSuccess)
            {
                Commit();
            }

            return isSuccess;
        }

        public async Task<Result<IEnumerable<JogadorDTO>>> GetAll()
        {
            var items = await _jogadorRepositorio.GetAll();

            return Result.Ok(items.Select(JogadorMapper.ConverParaDTO));
        }

        public async Task<Result<JogadorDTO>> GetById(int jogadorId)
        {
            try
            {
                var jogador = await _jogadorRepositorio.GetById(jogadorId);

                if (jogador == null)
                {
                    return Result.Fail<JogadorDTO>($"Jogador com ID {jogadorId} não encontrado.");
                }

                return Result.Ok(JogadorMapper.ConverParaDTO(jogador));
            }
            catch (Exception ex)
            {
                return Result.Fail<JogadorDTO>($"Erro ao buscar jogador com ID {jogadorId}: {ex.Message}");
            }
        }

        public void Update(JogadorDTO dTO)
        {
            var entidade = JogadorMapper.ConverterParaEntidade(dTO);

            _jogadorRepositorio.Update(entidade);

            Commit();
        }

        private List<HeroiDTO> RemoverCodinomesDuplicados(List<string> codinomesJaUsados, List<HeroiDTO> herois)
        {
            var heroisSemDuplicados = herois.Where(hero => !codinomesJaUsados.Contains(hero.Codinome)).ToList();
            return heroisSemDuplicados;
        }

        private string ObterCodiNome(List<string> codinomesLivres)
        {
            var random = new Random();
            var randomIndex = random.Next(codinomesLivres.Count);

            return codinomesLivres[randomIndex];
        }
    }
}
