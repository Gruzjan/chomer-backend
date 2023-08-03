using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chomer_backend.Models.DTO
{

    public class CreateRewardDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Cost is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Cost must be a positive number.")]
        public int Cost { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater or equal {1}.")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "HouseId is required.")]
        public int HouseId { get; set; }
    }

    public class RewardDTO : CreateRewardDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "House is required.")]
        public House House { get; set; }
    }
}
