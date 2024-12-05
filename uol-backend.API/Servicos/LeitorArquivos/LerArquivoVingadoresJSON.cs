using Newtonsoft.Json;
using System.Xml.Linq;
using uol_backend.DOMAIN.DTOs;
using uol_backend.DOMAIN.Entidades.Interfaces;

namespace uol_backend.API.Servicos.LeitorArquivos
{
    public class LerArquivoVingadoresJSON : ILeitorArquivoHerois
    {
        HttpClient _httpCliente = new HttpClient();
        private readonly IConfiguration _configuration;

        public LerArquivoVingadoresJSON(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<HeroiDTO>> LerArquivo()
        {
            var baseUrl = _configuration.GetConnectionString("VingadoresAPI");
            var response = await _httpCliente.GetAsync(baseUrl);
            var content = await response.Content.ReadAsStringAsync();

            var vingadores = JsonConvert.DeserializeObject<VingadoresLeitorDTO>(content);

            return vingadores?.Heróis ?? new List<HeroiDTO>();
        }
    }
}
