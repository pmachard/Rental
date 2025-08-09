using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarServices _service;
        public CarController(CarServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            var cars = await _service.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetById(int id)
        {
            var car = await _service.GetByIdAsync(id);
            return car == null ? NotFound() : Ok(car);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            var createdCar = await _service.AddAsync(car);
            return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Car car)
        {
               if (id != car.Id)
                    return BadRequest();

                var updated = await _service.UpdateAsync(car);
                if (!updated)
                    return NotFound();

                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            
            return NoContent();
        }
    }
}