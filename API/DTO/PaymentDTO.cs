using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Month { get; set; }
        [Column(TypeName = "date")]
        public DateTime Year { get; set; }
        public string Purpose {get; set;}
        public DateTime PaymentDate { get; set; }
    }
}