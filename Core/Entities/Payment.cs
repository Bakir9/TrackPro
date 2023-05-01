namespace Core.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; }
        public List<UserPayment> UserPayments { get; set; }
    }
}