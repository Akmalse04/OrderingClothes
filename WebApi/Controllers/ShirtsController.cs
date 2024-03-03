using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Filters.ExceptionFilter;
using WebApi.Models;
using WebApi.Models.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController:ControllerBase
    {
        
        [HttpGet]
       //Route("/shirts")]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }
        [HttpGet("{id}")]
        //Route("/shirts/{id}")]
        // public string GetShirtById(int id, [FromQuery] string color)
        //public string GetShirtById(int id, [FromHeader(Name ="Color")] string color)
        //    public string GetShirtById(int id)
        //{
        //    return $"Reading shirt by id:{id}";
        //}
        [Validate_ShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            
            return Ok(ShirtRepository.GetShirtById(id));
        }
        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
       //Route("/shirts")]
        //public string CreateShirt([FromForm]Shirt shirt)
             public IActionResult CreateShirt([FromBody] Shirt shirt)
        {   
           
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
            //return Ok($"Crearing shirt");
        }
        [HttpPut("{id}")]
       // [Validate_ShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
       //Route("/shirts/{id}")]
        public IActionResult Updateshirt(int id,Shirt shirt)
        {
           ShirtRepository.UpdateShirt(shirt);
           return NoContent();
        }
        [HttpDelete("{id}")]
        [Validate_ShirtIdFilter]
        //Route("/shirts/{id}")]
        public IActionResult DeleteShirt(int id) {
            var shirt=ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }
    }
}
