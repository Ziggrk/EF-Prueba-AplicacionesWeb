using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class FarmerSQLInfrastructure : IFarmerInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public FarmerSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Farmer>> GetAllAsync()
    {
        var farmers = await exampleDbContext.Farmers.ToListAsync();
        return farmers;
    }

    public Task<Farmer?> GetByUsername(String name)
    {
        var farmer = exampleDbContext.Farmers.Where(farmer => farmer.Username == name).SingleOrDefaultAsync();
        return farmer;
    }

    public async Task<Farmer?> GetByEmail(String email)
    {
        var farmer = await exampleDbContext.Farmers.Where(farmer => farmer.Email == email).SingleOrDefaultAsync();
        return farmer;
    }

    public async Task<bool> SaveAsync(Farmer farmer)
    {
        await exampleDbContext.Farmers.AddAsync(farmer);
        await exampleDbContext.SaveChangesAsync();
        return true;
    }
}