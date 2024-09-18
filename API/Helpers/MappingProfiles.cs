using API.DTO;
using API.DTO.User;
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
            CreateMap<User, UserActivityDTO>();
            CreateMap<UserActivity, UserInfoDTO>();
            CreateMap<Activity, UserActivityDTO>();
           
            CreateMap<Activity, ActivityDTO>()
                .ForMember(ua => ua.UserActivities, a => a.MapFrom(k => k.UserActivities))
                .ForMember(ua => ua.Users, a => a.MapFrom(k => k.Users));
            CreateMap<User, UserInfoDTO>();
            
           
            CreateMap<Core.Entities.Activity, UserForActivityDTO>()
                .ForMember(k => k.ActivityId, o => o.MapFrom(p => p.Id))
                .ForMember(k => k.Users, o => o.MapFrom(p => p.UserActivities.Select(x => x.User).ToList()));
            CreateMap<UserActivity, UserActivityDTO>()
                 .ForMember(a => a.FirstName, u => u.MapFrom(k => k.User.FirstName))
                 .ForMember(a => a.LastName, u => u.MapFrom(k => k.User.LastName));
        }
    }
}