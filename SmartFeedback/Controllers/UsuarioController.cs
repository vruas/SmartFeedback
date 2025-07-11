using Microsoft.AspNetCore.Mvc;
using SmartFeedback.Data.Dtos;
using SmartFeedback.Services;
using System.Threading.Tasks;

namespace SmartFeedback.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastrarUsuario(dto);
            return Ok("Usuário cadastrado!");
        }
    }
}
