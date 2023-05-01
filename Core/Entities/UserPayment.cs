namespace Core.Entities
{
    public class UserPayment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }  
        public DateTime PaymentDate { get; set; }   
    }
}