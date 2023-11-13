using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
      public int AssociationId { get; set; }
      public Association Association { get; set; }
      public List<Childs> Childs { get; set; }
      public List<UserChilds> UserChilds { get; set; }
      public List<Activity> Activities { get; set; }
      public List<UserActivities> UserActivities { get; } = new();
      [Column(TypeName = "date")]
      public DateTime LastActive {get; set;}
      
      public List<Payment> Payments { get; } = new List<Payment>();
    }
}