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
        [ForeignKey(nameof(User))]
        public int CreatedById { get; set; }
        [ForeignKey(nameof(User))]
        public int? AssignedToId { get; set; }
        //icon
    }
}
