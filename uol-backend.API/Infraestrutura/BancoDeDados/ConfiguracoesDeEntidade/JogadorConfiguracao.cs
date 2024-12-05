using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uol_backend.DOMAIN.Entities;

namespace uol_backend.API.Infraestrutura.BancoDeDados.ConfiguracoesDeEntidade
{
    public class JogadorConfiguracao : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
