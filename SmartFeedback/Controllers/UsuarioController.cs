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

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastrarUsuario(dto);
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            await _usuarioService.Login(dto);
            return Ok("Usuário logado com sucesso!");
        }
    }
}
