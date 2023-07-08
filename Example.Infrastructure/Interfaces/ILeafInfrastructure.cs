using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface ILeafInfrastructure
{
    Task<List<Leaf>> GetByTreeId(int id);
    Task<bool> SaveAsync(Leaf leaf);
}