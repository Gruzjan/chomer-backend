using System.ComponentModel.DataAnnotations;

namespace chomer_backend.Models.DTO
{
    public class CreateHouseUserDTO
    {
        [Required(ErrorMessage = "Points are required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Points must be positive.")]
        public int Points { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "HouseId is required.")]
        public int HouseId { get; set; }
        [Required(ErrorMessage = "Bool IsAdmin is required.")]
        public bool IsAdmin { get; set; } = false;
    }

    public class HouseUserDTO : CreateHouseUserDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public User User { get; set; }
        [Required(ErrorMessage = "House is required.")]
        public House House { get; set; }
    }
}
