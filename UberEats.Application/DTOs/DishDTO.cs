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
    public class DishDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsGlutenFree { get; set; }
        public int? Calories { get; set; }

        public int CategoryId { get; set; }
        [MaxLength(100)]
        public CategoryName CategoryName { get; set; }
        [MaxLength(200)]
        public string? CategoryDescription { get; set; }
        
        [MaxLength(300)]
        public List<DishImage> ImageUrls { get; set; } = new List<DishImage>();
        public int RestaurantId { get; set; }
    }
}
