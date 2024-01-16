using Core.Entities;

namespace API.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string CreatedBy { get; set; } 
        public List<UserActivities> Users { get; set; }
    }
}