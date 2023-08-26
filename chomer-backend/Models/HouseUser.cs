using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models
{
    public class HouseUser
    {
        public int Id { get; set; }
        public int Points { get; set; } = 0;
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        public House House { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;
        public virtual IList<Chore> AssignedChores { get; set; }
        public virtual IList<Chore> CreatedChores { get; set; }

    }
}
