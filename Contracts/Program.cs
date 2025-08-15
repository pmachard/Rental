
using ContractService.Data;
using ContractService.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // <- doit correspondre au port interne
});

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration with Npgsql
builder.Services.AddDbContext<ContractDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ContractService injection
builder.Services.AddScoped<ContractServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
