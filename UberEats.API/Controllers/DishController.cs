using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberEats.Application.Dishes.Commands.CreateDish;
using UberEats.Application.Images.AddImage;

namespace UberEats.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IMediator _mediator ;
        public DishController(IMediator mediator )
        {
            _mediator = mediator ;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId,[FromForm] CreateDishCommand command)
        {
            command.RestaurantId = restaurantId ;
            int DishId = await _mediator.Send(command);
            if(command?.ImageFiles?.Count > 0)
            {
                await _mediator.Send(new AddImageCommand() { ImageFiles = command.ImageFiles,DishId=DishId });
            }
            return NoContent();
        }
    }
}
