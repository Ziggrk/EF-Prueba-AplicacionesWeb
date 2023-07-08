using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface IFarmlandInfrastructure
{
    Task<List<Farmland>> GetByFarmerId(int id);
    Task<Farmland?> GetByLocation(Farmland farmland);
}