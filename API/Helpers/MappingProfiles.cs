using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(u => u.Payments, o => o.MapFrom(p => p.Payments));
            CreateMap<Payment, PaymentDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserActivityDTO>();//mozda treba
            CreateMap<UserActivities, UserActivityDTO>();
            CreateMap<Activity, UserActivityDTO>();
            CreateMap<Activity, ActivityDTO>();
            CreateMap<Core.Entities.Activity, UserForActivityDTO>()
                .ForMember(k => k.ActivityId, o => o.MapFrom(p => p.Id))
                .ForMember(k => k.Users, o => o.MapFrom(p => p.UserActivities.Select(x => x.User)));
        }
    }
}