using Microsoft.EntityFrameworkCore;
using uol_backend.API.Infraestrutura.BancoDeDados;
using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entities;

namespace uol_backend.API.Infraestrutura.Repositorio
{
    public class JogadorRepositorio : IJogadorRepositorio
    {
        private readonly BancoDataContext _bancoContext;

        public JogadorRepositorio(BancoDataContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void Add(Jogador entity)
        {
            _bancoContext.Add(entity);
        }

        public bool Delete(int jogadorId)
        {
            var jogador = _bancoContext
                .Jogadores
                .FirstOrDefault(x => x.Id == jogadorId);

            if(jogador == null)
            {
                return false;
            }

            _bancoContext.Jogadores.Remove(jogador);
            return true;
        }

        public async Task<IEnumerable<Jogador>> GetAll()
        {
            return await _bancoContext
                .Jogadores
                .ToListAsync();
        }

        public async Task<Jogador?> GetById(int jogadorId)
        {
            return await _bancoContext
                .Jogadores
                .FirstOrDefaultAsync(x => x.Id == jogadorId);
        }

        public async Task<List<string>> GetDisponibleCodinames(List<HeroiDTO> codinomes)
        {
            var codinomesList = codinomes.Select(x => x.Codinome).ToList(); 

            return await _bancoContext
                .Jogadores
                .AsNoTracking()
                .Where(x => codinomesList.Contains(x.Codinome))
                .Select(x => x.Codinome)
                .ToListAsync();
        }


        public void Update(Jogador entity)
        {
            _bancoContext.Jogadores.Update(entity);
        }
    }
}
