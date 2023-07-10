namespace chomer_backend.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        //icon
        public int HouseId { get; set; }
        public House House { get; set; }

    }
}
