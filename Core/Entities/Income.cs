using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public int UserId { get; set; } 
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}