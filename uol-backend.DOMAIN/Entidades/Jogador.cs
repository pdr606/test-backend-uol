using uol_backend.DOMAIN.Enumeradores;

namespace uol_backend.DOMAIN.Entities
{
    public class Jogador
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Codinome { get; set; } = string.Empty;
        public EGrupo Grupo { get; set; }

        public Jogador(string nome, string email, string telefone, EGrupo grupo)
        {
            Nome=nome;
            Email=email;
            Telefone=telefone;
            Grupo=grupo;
        }

        public Jogador VincularCodinome(string codinome)
        {
            Codinome = codinome;

            return this;
        }
    }
}
