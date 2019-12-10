using AutoMapper;
using API.Core.Dtos;
using API.Core.Entities;

namespace API.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CampaignDto, Campaign>();
            CreateMap<Goal, GoalDto>();
            CreateMap<GoalDto, Goal>();
        }
    }
}