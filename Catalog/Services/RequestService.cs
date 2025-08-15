using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Data;


namespace ProductService.Services
{
    public class RequestServices
    {
        private readonly CarDbContext _context;

        public RequestServices(CarDbContext context)
        {
            _context = context;
        }
        public async Task<Car?> GetFreeByCategoryAsync(string category)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => (c.Status == "FREE" && c.Category == category));
            return car;
        }
    }
}