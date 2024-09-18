using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.User
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Gender { get; set; }
        public DateOnly Birthday { get; set; }
    }
}