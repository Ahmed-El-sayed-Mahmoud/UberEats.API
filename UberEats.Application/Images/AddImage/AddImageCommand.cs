using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Application.Images.AddImage
{
    public class AddImageCommand:IRequest
    {
        public List<IFormFile> ImageFiles { get; set; }
        public int DishId { get; set; }
    }
}
