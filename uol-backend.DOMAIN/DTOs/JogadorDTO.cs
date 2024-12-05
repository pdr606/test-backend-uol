using uol_backend.DOMAIN.Enumeradores;

namespace uol_backend.DOMAIN.DTOs
{
    public record JogadorDTO
    {
        public long? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Codinome { get; set; } = string.Empty;
        public EGrupo Grupo { get; set; }
    }
}
