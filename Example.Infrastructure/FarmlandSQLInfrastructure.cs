using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class FarmlandSQLInfrastructure : IFarmlandInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public FarmlandSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Farmland>> GetByFarmerId(int id)
    {
        var farmlands = await exampleDbContext.Farmlands.Where(farmland => farmland.Farmer.Id == id).ToListAsync();
        return farmlands;
    }

    public async Task<Farmland?> GetByLocation(Farmland farmland)
    {
        var existingFarmland = await exampleDbContext.Farmlands
            .Where(f => f.Altitude == farmland.Altitude
                        && f.Latitude == farmland.Latitude
                        && f.Longitude == farmland.Longitude)
            .SingleOrDefaultAsync();
        return existingFarmland;
    }
}