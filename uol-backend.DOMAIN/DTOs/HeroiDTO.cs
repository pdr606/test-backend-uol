using Newtonsoft.Json;
using System.Xml.Serialization;

namespace uol_backend.DOMAIN.DTOs
{
    public class HeroiDTO
    {
        public string Codinome { get; set; } = string.Empty;
    }

    public class LeitorDTO
    {
        [JsonProperty("vingadores")]
        [XmlElement("codinomes")]
        public List<HeroiDTO> Heróis { get; set; } = new List<HeroiDTO>();
    }

    public class VingadoresLeitorDTO : LeitorDTO
    {
    }

    public class LigaDaJusticaLeitorDTO : LeitorDTO
    {
    }
}
