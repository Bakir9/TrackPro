using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTO.Payments
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Datum { get; set; }
        public bool IsYear { get; set; }
        public string Month { get; set; }
        public int PaymentPurposeId { get; set; }
        public int ReceiptNr { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
    }
}