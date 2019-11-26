using AutoMapper;
using API.Core.Dtos.Auth;
using API.Core.Entities.Auth;
using API.Core.Dtos;
using API.Core.Entities;

namespace API.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticateEntity, AuthenticateDto>();
            CreateMap<User, UserDto>();
        }
    }
}