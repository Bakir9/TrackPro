using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public class UserActivity
    {
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public User User { get; set; } = null;
        public Activity Activity { get; set; } = null;
    }
}