using AutoMapper;
using SmartFeedback.Data.Dtos;
using SmartFeedback.Models;

namespace SmartFeedback.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
                
        }
    }
}
