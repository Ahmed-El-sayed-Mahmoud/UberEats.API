using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestaurantController( IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRestaurantsQuery());
            if (result == null)
            {
                return NotFound(new NotFoundError("No restaurants found."));
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurantById(int id)
        {
            RestaurantDTO? restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }
        [HttpPost("create")]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]

        public async Task<IActionResult> Create([FromForm]CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
           
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]

        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            await  _mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]

        public async Task<IActionResult> UpdateRestaurant([FromRoute]int id,UpdateRestaurantCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
     
        }
    }
}
