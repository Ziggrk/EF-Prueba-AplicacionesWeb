using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface IFarmerInfrastructure
{
    Task<List<Farmer>> GetAllAsync();
    Task<Farmer?> GetByUsername(String name);
    Task<Farmer?> GetByEmail(String email);
    Task<bool> SaveAsync(Farmer farmer);
}