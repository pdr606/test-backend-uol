using uol_backend.DOMAIN.Base;
using uol_backend.DOMAIN.DTOs;

namespace uol_backend.API.Servicos.Jogador
{
    public interface IJogadorService
    {
        Task Add(JogadorDTO dTO);
        void Update(JogadorDTO dTO);
        bool Delete(int jogadorId);
        Task<Result<IEnumerable<JogadorDTO>>> GetAll();
        Task<Result<JogadorDTO>> GetById(int jogadorId);
    }
}
