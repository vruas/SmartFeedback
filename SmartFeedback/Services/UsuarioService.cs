using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartFeedback.Data.Dtos;
using SmartFeedback.Models;

namespace SmartFeedback.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CadastrarUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Erro ao cadastrar usuário: " + string.Join(", ", resultado.Errors.Select(e => e.Description)));
            }
        }
    }
}
