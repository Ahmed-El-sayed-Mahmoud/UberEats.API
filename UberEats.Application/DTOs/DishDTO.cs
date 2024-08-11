using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace UberEats.Application.DTOs
{
    public class DishDTO
    {
        [MaxLength(100)]
        [Required (ErrorMessage ="Name of the dish is mandatory")]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsGlutenFree { get; set; }
        public int? Calories { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        
        public List<IFormFile> ImageUrls { get; set; } = new List<IFormFile>();
    }
}
