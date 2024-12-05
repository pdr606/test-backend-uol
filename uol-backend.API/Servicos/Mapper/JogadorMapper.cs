using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entities;

namespace uol_backend.API.Servicos.Mapper
{
    public static class JogadorMapper
    {
        public static DOMAIN.Entities.Jogador ConverterParaEntidade(JogadorDTO dTO)
        {
            return new DOMAIN.Entities.Jogador(
                dTO.Nome,
                dTO.Email,
                dTO.Telefone,
                dTO.Grupo);
        }

        public static JogadorDTO ConverParaDTO(DOMAIN.Entities.Jogador entidade)
        {
            return new JogadorDTO()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Email = entidade.Email,
                Telefone = entidade.Telefone,
                Codinome = entidade.Codinome,
                Grupo = entidade.Grupo
            };
        }
    }
}
