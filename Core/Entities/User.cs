namespace Core.Entities
{
    public class User : BaseEntity
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Title { get; set; }
      public string Gender { get; set; }    
      public DateOnly YearOfBirth { get; set; }
      public string Adress { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public string Country { get; set; }
      public string FamilyMember { get; set; }
      public string MarriageStatus { get; set; }
      public DateTime MemberFrom { get; set; }
      public string PaymentType { get; set; }
      public string Active { get; set; }
      public List<UserPayment> UserPayments { get; set; }
    }
}