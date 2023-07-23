namespace Core.Entities
{
    public class Payment : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string Purpose {get; set;}
        public DateTime PaymentDate { get; set; }
        public User User { get; set; }
    }
}

