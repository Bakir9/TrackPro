using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Childs
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
        public string AdditionalInfo { get; set; }
        public List<User> Users { get; set; }
        public List<UserChilds> UserChilds { get; set; }
    }
}