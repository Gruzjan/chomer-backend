using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }
        //invite link or smth
    }
}
