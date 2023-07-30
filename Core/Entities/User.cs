using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

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
    //  public int AssociationId { get; set; }
     // public List<Activity> OtherActivities { get; set; }
      
      [Column(TypeName = "date")]
      public DateTime MemberFrom { get; set; } = DateTime.Now;
      public int Active { get; set; }
      
      [Column(TypeName = "date")]
      public DateTime LastActive {get; set;}
      public List<Payment> UserPayments{ get; }
    }
}
// posebna stranica za udruzenja, pregled clanova
//dodati atribut za udruzenja
//dodati stranicu za ostale aktivnosti (mekteb, hor, hifz, bosanski i arapski jezik)
//unutar sidebara, dodati submenu za ostale aktivnosti, gdje ce biti smjesteni mekteb,hor...