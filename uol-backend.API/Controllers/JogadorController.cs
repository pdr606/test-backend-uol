using Microsoft.AspNetCore.Mvc;
using uol_backend.API.Servicos.Jogador;
using uol_backend.DOMAIN.DTOs;

namespace uol_backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorService _jogadorService;

        public JogadorController(IJogadorService jogadorService)
        {
            _jogadorService=jogadorService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] JogadorDTO dTO)
        {
            await _jogadorService.Add(dTO);

            return Ok();
        }
    }
}
