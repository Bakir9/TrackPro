namespace Core.Entities
{
    public class SubActitivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MyProperty { get; set; }
        public int ActivityId { get; set; }
        public List<User> Users { get; set; }
    }
}