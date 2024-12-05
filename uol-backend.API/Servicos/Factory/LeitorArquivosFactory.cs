using uol_backend.API.Servicos.LeitorArquivos;
using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entidades.Interfaces;
using uol_backend.DOMAIN.Enumeradores;

namespace uol_backend.API.Servicos.Factory
{
    public class LeitorArquivosFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LeitorArquivosFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILeitorArquivoHerois ObterLeitor(EGrupo grupo)
        {
            return grupo switch
            {
                EGrupo.VINGADORES => _serviceProvider.GetRequiredService<LerArquivoVingadoresJSON>(),
                EGrupo.LIGA_DA_JUSTICA => _serviceProvider.GetRequiredService<LerArquivoLigaDaJusticaXML>(),
                _ => throw new ArgumentException("Grupo não suportado", nameof(grupo))
            };
        }

    }
}
