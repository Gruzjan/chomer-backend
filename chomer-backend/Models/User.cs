namespace chomer_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual IList<HouseUser> HouseUsers { get; set; }
        public virtual IList<House> Houses { get; set; }

    }
}
