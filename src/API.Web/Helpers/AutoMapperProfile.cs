using AutoMapper;
using API.Core.Dtos;
using API.Core.Entities;
using System.Collections.Generic;
using API.Core.Dtos.Mollie;

namespace API.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CampaignDto, Campaign>();
            CreateMap<GoalDto, Goal>();
            CreateMap<MolliePayment, ListPaymentDto>()
                .ForMember(
                    dest => dest.GoalId,
                    opt => opt.MapFrom(src => src.Goal.Id)
                )
                .ForMember(
                    dest => dest.SubGoalId,
                    opt => opt.MapFrom(src => src.SubGoal.Id)
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString())
                );
        }
    }
}