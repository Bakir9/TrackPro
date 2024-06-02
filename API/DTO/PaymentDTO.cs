using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Purpose {get; set;}
        public DateTime PaymentDate { get; set; }
    }
}