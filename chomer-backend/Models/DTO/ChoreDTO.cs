﻿using System.ComponentModel.DataAnnotations;

namespace chomer_backend.Models.DTO
{
    public class ChoreDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name must be between {2} and {1} characters.", MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Value must be be higher or equal {1}.")]
        public int? Value { get; set; }
        [MaxLength(255, ErrorMessage = "Description must be shorter than {1} characters.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "HouseId is required.")]
        public int HouseId { get; set; }
        [Required(ErrorMessage = "CreatedById is required.")]
        public int CreatedById { get; set; }
        public int AssignedToId { get; set; }

    }
}
