using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? Value { get; set; }
        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        public House House { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public int? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }
        //icon
    }
}
