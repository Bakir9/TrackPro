using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<int>
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }  
      [Column(TypeName = "date")]
      public DateOnly Birthday { get; set; }
      public string Adress { get; set; }
      public string Country { get; set; }
      public string Nationality { get; set; }
      [Column(TypeName = "date")]
      public DateTime MemberFrom { get; set; } = DateTime.Now;
      public int Active { get; set; }
      public string Title { get; set; }
      public string Password { get; set; }
      public string Phone { get; set; }
      public string MarriageStatus { get; set; }
      public int AssociationId { get; set; }
      public Association Association { get; set; }
      public List<Childs> Childs { get; set; }
      public List<UserChilds> UserChilds { get; set; }
      public List<Activity> Activities { get; } = new();
      public List<UserActivity> UserActivities { get; } = new();
      [Column(TypeName = "date")]
      public DateTime LastActive {get; set;}
      public List<Payment> Payments { get; } = new List<Payment>();
    }
}