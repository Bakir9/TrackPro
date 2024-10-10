namespace API.DTO
{
    public class UserLoginDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }   
        public string Token { get; set; } 
    }
}