using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.RestaurantsUseCase;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {

        private readonly IGetAllRestaurantsUseCase getAllRestaurantsUseCase;
        private readonly IGetRestaurantByIdUseCase getRestaurantByIdUseCase;


        public RestaurantsController
        (
            IGetAllRestaurantsUseCase getAllRestaurantsUseCase,
            IGetRestaurantByIdUseCase getRestaurantByIdUseCase
        )
        {
            this.getAllRestaurantsUseCase = getAllRestaurantsUseCase;
            this.getRestaurantByIdUseCase = getRestaurantByIdUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await getAllRestaurantsUseCase.Execute();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await getRestaurantByIdUseCase.Execute(id);
            return Ok(result);
        }
    }
}
