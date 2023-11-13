using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Childs : BaseEntity
    {
       public string AdditionalInfo { get; set; }
       public List<User> Users { get; set; }
       public List<UserChilds> UserChilds { get; set; }
    }
}