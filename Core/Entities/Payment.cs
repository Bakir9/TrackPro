using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Purpose {get; set;}
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        public User User { get; set; }
    }
}

