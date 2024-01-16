namespace API.DTO
{
    public class UserLoginDTO
    {
        public int AppUserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }   
        public string Token { get; set; } 
    }
}