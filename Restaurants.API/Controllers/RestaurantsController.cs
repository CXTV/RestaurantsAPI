using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
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
        private readonly ICreateRestaurantUseCase createRestaurantUseCase;


        public RestaurantsController
        (
            IGetAllRestaurantsUseCase getAllRestaurantsUseCase,
            IGetRestaurantByIdUseCase getRestaurantByIdUseCase,
            ICreateRestaurantUseCase createRestaurantUseCase
        )
        {
            this.getAllRestaurantsUseCase = getAllRestaurantsUseCase;
            this.getRestaurantByIdUseCase = getRestaurantByIdUseCase;
            this.createRestaurantUseCase = createRestaurantUseCase;
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

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto) 
        {
            int id = await createRestaurantUseCase.Execute(createRestaurantDto);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
