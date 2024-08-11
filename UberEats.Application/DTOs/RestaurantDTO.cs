using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;

namespace UberEats.Application.DTOs
{
    public class RestaurantDTO
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Range(0, 5)]
        public decimal Rating { get; set; }
        public bool IsOpen { get; set; }
        public bool? DeliveryAvailable { get; set; }
        public decimal? DeliveryFee { get; set; }

        [MaxLength(100)]
        public string? Street { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(100)]
        public string? State { get; set; }
        [MaxLength(100)]

        public string? PostalCode { get; set; }
        [MaxLength(100)]
        public string? Country { get; set; }
        
        public ICollection<DishDTO>? Dishes { get; set; } = new List<DishDTO>();
    }
}
