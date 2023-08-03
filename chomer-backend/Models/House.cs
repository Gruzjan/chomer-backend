using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        //invite link or  smth
        public virtual IList<Chore> Chores { get; set; }
        public virtual IList<HouseUser> HouseUsers { get; set; }
        public virtual IList<Reward> Rewards { get; set; }

    }
}
