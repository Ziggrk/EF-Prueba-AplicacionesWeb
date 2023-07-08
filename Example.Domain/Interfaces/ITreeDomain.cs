using Example.Infrastructure.Models;

namespace Example.Domain.Interfaces;

public interface ITreeDomain
{
    public Task<bool> SaveAsync(Tree tree);
}