using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly RequestServices _service;
        public RequestController(RequestServices service)
        {
            _service = service;
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<Car>> GetFreeByCategory(string category)
        {
            var car = await _service.GetFreeByCategoryAsync(category);
            return car == null ? NotFound() : Ok(car);
        }
    }
}