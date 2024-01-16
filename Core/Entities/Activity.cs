using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<UserActivities> UserActivities { get; } = new();
    }
}