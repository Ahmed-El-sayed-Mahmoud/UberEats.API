using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain.Entities
{
    public enum CategoryName
    {
        Appetizers,
        MainCourses,
        Desserts,
        Beverages,
        Specialties,
        Salads,
        Soups,
        Sandwiches,
        Sides,
        KidsMenu
    }
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public CategoryName Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Dish>? Dishes { get; set; } = new List<Dish>();


    }
}
