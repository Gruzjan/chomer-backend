namespace chomer_backend.Models
{
    public class HouseUser
    {
        public int Id { get; set; }
        public int Points { get; set; } = 0;
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
