using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace UberEats.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommand:IRequest<int>
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsGlutenFree { get; set; }
        public int? Calories { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<IFormFile>? ImageFiles { get; set; } = new List<IFormFile>();
        public int RestaurantId { get; set; }
    }
}
