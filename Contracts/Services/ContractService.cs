using Microsoft.EntityFrameworkCore;
using ContractService.Data;
using Contracts.Models;


namespace ContractService.Services
{
    public class ContractServices
    {
        private readonly ContractDbContext _context;

        public ContractServices(ContractDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contract>> GetAllAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<Contract?> GetByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<Contract> AddAsync(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            return contract;
        }

        public async Task<bool> UpdateAsync(Contract contract)
        {
            var exists = await _context.Contracts.AnyAsync(c => c.Id == contract.Id);
            if (!exists) return false;

            _context.Entry(contract).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
                await _context.SaveChangesAsync();
            }
        }
    }
}