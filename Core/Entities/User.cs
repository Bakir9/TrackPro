using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Entities
{
    public class User : BaseEntity
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Title { get; set; }
      public string Gender { get; set; }    
      
      [Column(TypeName = "date")]
      public DateOnly Birthday { get; set; }
      public string Adress { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public string Phone { get; set; }
      public string Country { get; set; }
      public string Nationality { get; set; }
      public string MarriageStatus { get; set; }
      
      [Column(TypeName = "date")]
      public DateTime MemberFrom { get; set; } = DateTime.Now;
      public string Active { get; set; }
      
      [Column(TypeName = "date")]
      public DateTime LastActive {get; set;}
      public List<Payment> UserPayments{ get; }
      
    }
}