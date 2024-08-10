using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberEats.API.Errors;
using UberEats.Application.DTOs;
using UberEats.Application.IServices;
using UberEats.Domain.Entities;

namespace UberEats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _services;
        public RestaurantController( IRestaurantServices restaurantServices)
        {
            _services = restaurantServices;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            return Ok(await _services.GetRestaurantsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            RestaurantDTO? restaurant = await _services.GetRestaurantByIdAsync(id);
            if(restaurant == null)
            {
                return NotFound(new NotFoundError("No Restaurant was Found"));
            }
            return Ok(restaurant);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateRestaurantDto createRestaurantDto)
        {
            int id = await _services.CreateAsync(createRestaurantDto);
            if(id == -1) 
            {
                return Conflict(new ConflictError("A restaurant with the same name alreay Exist"));
            }
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }
    }
}
