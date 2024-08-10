using System.ComponentModel.DataAnnotations;

namespace UberEats.Application.DTOs
{
    public class CreateRestaurantDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string? PhoneNumber { get; set; }
        [Range(0, 5)]
        public decimal Rating { get; set; }
        public bool IsOpen { get; set; }
        public bool? DeliveryAvailable { get; set; }
        public decimal? DeliveryFee { get; set; }
        [EmailAddress]
        [Required]
        public string? ContactEmail { get; set; }

        public string? Street { get; set; }

        [MaxLength(100)]
        [Required]
        public string? City { get; set; }
        [MaxLength(100)]
        public string? State { get; set; }
        [MaxLength(100)]

        public string? PostalCode { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Country { get; set; }
    }
}
