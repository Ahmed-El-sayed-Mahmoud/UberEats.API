using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Application.Restauransts.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand:IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
       
        [MaxLength(100)]
        [Phone]
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public bool IsOpen { get; set; } = true;
        [Required]
        public bool? DeliveryAvailable { get; set; }
        [Required]
        public decimal? DeliveryFee { get; set; }
        [EmailAddress]
        [Required]
        public string? ContactEmail { get; set; }
    }
}
