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
        [ForeignKey(nameof(CreatedBy))]
        public int CreatedById { get; set; }
        public HouseUser CreatedBy { get; set; } = null!;
        [ForeignKey(nameof(AssignedTo))]
        public int? AssignedToId { get; set; }
        public HouseUser? AssignedTo { get; set; }
        //icon
    }
}
