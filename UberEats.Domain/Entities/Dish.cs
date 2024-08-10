using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; } 
        public bool? IsVegan { get; set; } 
        public bool? IsGlutenFree { get; set; }
        public int? Calories { get; set; } 

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(300)]
        public List<DishImage> ImageUrls { get; set; } =new List<DishImage>();
        public int RestaurantId { get; set; }
   
    }
    public class DishImage
    {
        public int Id { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        [MaxLength(300)]
        public string ImageUrl { get; set; }
    }

}
