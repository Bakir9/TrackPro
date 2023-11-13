using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Association
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<User> Users { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}