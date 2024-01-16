using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BaseEntity
    {
         [Key]
        public int Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }    
        [Column(TypeName = "date")]
        public DateOnly Birthday { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        [Column(TypeName = "date")]
        public DateTime MemberFrom { get; set; } = DateTime.Now;
        public int Active { get; set; }
    }
}