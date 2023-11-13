using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserChilds
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChildId { get; set; }
        public User Users { get; set; }  
        public Childs Childs { get; set; }  
    }
}