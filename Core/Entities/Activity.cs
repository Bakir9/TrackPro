using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        [Required]
        public int UserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<User> Users { get; } = new();
        public List<UserActivity> UserActivities { get; } = new ();
    }
}