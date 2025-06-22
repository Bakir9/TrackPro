using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentPurposeId { get; set; }
        public PaymentPurpose Purpose { get; set; } 
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        public bool IsYear { get; set; }
        public DateTime Datum { get; set; }
        public int ReceiptNr { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
    }
}

