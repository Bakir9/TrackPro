using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Month { get; set; } //moze biti mjesec za clanarinu ili semestar za neki od kurseva
        [Column(TypeName = "date")]
        public DateTime Year { get; set; }
        public string Purpose {get; set;}
        public DateTime PaymentDate { get; set; }
        public User User { get; set; }
    }
}

