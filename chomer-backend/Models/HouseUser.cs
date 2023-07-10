namespace chomer_backend.Models
{
    public class HouseUser
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public User User { get; set; }
        public House House { get; set; }
        public bool IsAdmin { get; set; }
    }
}
