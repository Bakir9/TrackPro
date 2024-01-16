namespace API.DTO
{
    public class UserForActivityDTO
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public List<UserActivityDTO> Users { get; set; }  
    }
}