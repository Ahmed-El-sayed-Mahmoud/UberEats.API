using MediatR;
using Microsoft.AspNetCore.Mvc;
using UberEats.API.Errors;
using UberEats.Application.DTOs;
using UberEats.Application.Restauransts.Commands.CreateRestaurant;
using UberEats.Application.Restauransts.Commands.DeleteRestaurant;
using UberEats.Application.Restauransts.Commands.UpdateRestaurant;
using UberEats.Application.Restauransts.Quiries.GetAllRestaurants;
using UberEats.Application.Restauransts.Quiries.GetRestaurantById;



namespace UberEats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestaurantController( IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRestaurantsQuery());
            if (result == null)
            {
                return NotFound(new NotFoundError("No restaurants found."));
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            RestaurantDTO? restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            if(restaurant == null)
            {
                return NotFound(new NotFoundError("No Restaurant was Found"));
            }
            return Ok(restaurant);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm]CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            if(id == -1) 
            {
                return Conflict(new ConflictError("A restaurant with the same name alreay Exist"));
            }
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var success=await  _mediator.Send(new DeleteRestaurantCommand(id));
            if (!success)
                return NotFound(new NotFoundError("No Restaurant with this ID was found"));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute]int id,UpdateRestaurantCommand command)
        {
            command.Id = id;
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound(new NotFoundError("No Restaurant with this ID was found"));
            return NoContent();
     
        }
    }
}
