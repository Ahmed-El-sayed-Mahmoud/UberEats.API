using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        [MaxLength(100)]
       
        public string Name { get; set; }
        [MaxLength(100)]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Range(0, 5)]
        [Column(TypeName = "decimal(5,1)")]
        public decimal Rating { get; set; }
        public bool IsOpen { get; set; }
        public bool? DeliveryAvailable { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? DeliveryFee { get; set; }
        [EmailAddress]
        public string? ContactEmail { get; set; }
        //public List<string>? Reviews { get; set; } = new List<string>();
        public Address? Address { get; set; }
        public ICollection<Dish>? Dishes { get; set; }=new List<Dish>(); 
    }
}
