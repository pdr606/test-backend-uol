using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entities;

namespace uol_backend.API.Infraestrutura.Repositorio
{
    public interface IJogadorRepositorio
    {
        void Add(Jogador entity);
        void Update(Jogador entity);
        bool Delete(int jogadorId);
        Task<List<string>> GetDisponibleCodinames(List<HeroiDTO> codinomes);
        Task<IEnumerable<Jogador>> GetAll();
        Task<Jogador?> GetById(int jogadorId);
    }
}
