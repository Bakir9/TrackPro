using API.DTO.User;
using Core.Entities;

namespace API.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string CreatedBy { get; set; } 
        public List<UserInfoDTO> Users { get; set; }
        public List<UserActivityDTO> UserActivities {get; set;}
    }
}