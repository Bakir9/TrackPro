using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Income : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public int UserId { get; set; }
        public User User {get; set;}
    }
}