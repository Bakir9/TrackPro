using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Association : BaseEntity
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<User> User { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}