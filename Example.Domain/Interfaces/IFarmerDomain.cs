using Example.Infrastructure.Models;

namespace Example.Domain.Interfaces;

public interface IFarmerDomain
{
    public Task<bool> SaveAsync(Farmer farmer);
}