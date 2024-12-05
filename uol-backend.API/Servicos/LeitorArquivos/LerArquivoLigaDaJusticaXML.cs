using System.Xml.Linq;
using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entidades.Interfaces;

namespace uol_backend.API.Servicos.LeitorArquivos
{
    public class LerArquivoLigaDaJusticaXML : ILeitorArquivoHerois
    {
        HttpClient _httpCliente = new HttpClient();
        private readonly IConfiguration _configuration;

        public LerArquivoLigaDaJusticaXML(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<HeroiDTO>> LerArquivo()
        {
            var baseUrl = _configuration.GetConnectionString("LigaDaJusticaAPI");
            var response = await _httpCliente.GetAsync(baseUrl);

            XDocument xdoc = XDocument.Parse(await response.Content.ReadAsStringAsync());

            var ligaDaJustica = xdoc
                .Descendants("codinome")
                .Select(x => new HeroiDTO
                {
                    Codinome = x.Value
                })
                .ToList();

            return ligaDaJustica;
        }
    }
}
