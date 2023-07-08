using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface ITreeInfrastructure
{
    Task<List<Tree>> GetAllAsync();
    Task<Tree?> GetByUsername(String username);
    Task<Tree?> GetByIdAsync(int id);
    Task<bool> SaveAsync(Tree tree);
}