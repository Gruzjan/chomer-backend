namespace chomer_backend.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Value { get; set; }
        public User CreatedBy { get; set; }
        public User? AssignedTo { get; set; }
        //icon
    }
}
