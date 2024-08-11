using MediatR;
using UberEats.Application.DTOs;

namespace UberEats.Application.Restauransts.Quiries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery:IRequest<IEnumerable<RestaurantDTO>?>
    {

    }
}
