using Example.Infrastructure.Models;

namespace Example.Domain.Interfaces;

public interface ILeafDomain
{
    public Task<bool> SaveAsync(Leaf leaf);
}