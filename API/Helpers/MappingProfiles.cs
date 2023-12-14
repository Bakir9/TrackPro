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
        }
    }
}