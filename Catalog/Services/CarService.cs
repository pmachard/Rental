using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Data;


namespace ProductService.Services
{
    public class CarServices
    {
        private readonly CarDbContext _context;

        public CarServices(CarDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> UpdateAsync(Car car)
        {
            var exists = await _context.Cars.AnyAsync(c => c.Id == car.Id);
            if (!exists) return false;

            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}