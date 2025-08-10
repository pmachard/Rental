using Microsoft.EntityFrameworkCore;
using Contracts.Models;

namespace ContractService.Data;

public class ContractDbContext : DbContext
{
    public ContractDbContext(DbContextOptions<ContractDbContext> options)
        : base(options) { }

    public DbSet<Contract> Contracts => Set<Contract>();
}