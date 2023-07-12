namespace chomer_backend.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Value { get; set; }
        public int HouseId { get; set; }
        public int CreatedById { get; set; }
        public int? AssignedToId { get; set; }
        //icon
    }
}
