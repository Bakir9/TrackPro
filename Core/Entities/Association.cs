namespace Core.Entities
{
    public class Association : BaseEntity
    {
        public string Name { get; set; }
        public int CreatedByUser { get; set; }
        public List<User> User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}