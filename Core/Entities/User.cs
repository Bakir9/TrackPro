using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Core.Entities
{
    public class User : BaseEntity
    {
      public string Title { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public string Phone { get; set; }
      public string MarriageStatus { get; set; }
      public Childs Childs { get; set; }
      [Column(TypeName = "date")]
      public DateTime LastActive {get; set;}
      public List<Payment> UserPayments{ get; }
    }
}
// posebna stranica za udruzenja, pregled clanova
//dodati atribut za udruzenja
//dodati stranicu za ostale aktivnosti (mekteb, hor, hifz, bosanski i arapski jezik)
//unutar sidebara, dodati submenu za ostale aktivnosti, gdje ce biti smjesteni mekteb,hor...