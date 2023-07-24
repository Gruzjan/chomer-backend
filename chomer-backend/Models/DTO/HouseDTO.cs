using System.ComponentModel.DataAnnotations;

namespace chomer_backend.Models.DTO
{
    public class CreateHouseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name must be between {2} and {1} characters.", MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "OwnerId is required.")]
        public int OwnerId { get; set; }
    }

    public class HouseDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }
}
