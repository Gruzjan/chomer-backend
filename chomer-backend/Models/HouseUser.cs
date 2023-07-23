using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models
{
    public class HouseUser
    {
        public int Id { get; set; }
        public int Points { get; set; } = 0; 
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
