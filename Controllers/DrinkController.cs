using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly DrinkService _drinkService;
        public DrinkController(DrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet("GetDrinks")]
        public IActionResult Get()
        {
            return Ok(_drinkService.GetAll());
        }

        [HttpGet("GetDrink/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_drinkService.GetById(id));
        }

        [HttpPost("PostDrinks")]
        public IActionResult Post(Drink drink)
        {
            if (_drinkService.GetById(drink.Id) is not null)
                return BadRequest("Drink id already exists.");

            _drinkService.Add(drink);
            return Ok();
        }

        [HttpPut("PutDrinks")]

        public IActionResult Put(Drink drink)
        {
            if (_drinkService.GetById(drink.Id) is null)
                return BadRequest("Drink doesn't exist.");
            _drinkService.Update(drink.Id, drink);
            return Ok();
        }


        [HttpDelete("DeleteDrink")]
        public IActionResult Delete(int id)
        {
            if (_drinkService.GetById(id) is not null)
                _drinkService.Delete(id);
            return Ok();

        }

        [HttpGet("GetOdd")]
        public IActionResult GetOdd()
        {
            var oddItems = _drinkService.GetOddDrinks();
            return Ok(oddItems);
        }

        [HttpGet("Pages")]
        public IActionResult Pages(int page, int noelements)
        {
            return Ok(_drinkService.returnPage(page - 1, noelements));
        }


    }
}