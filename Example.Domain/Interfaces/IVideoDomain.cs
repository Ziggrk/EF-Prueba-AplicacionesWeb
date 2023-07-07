using Example.Infrastructure.Models;

namespace Example.Domain.Interfaces;

public interface IVideoDomain
{
    public Task<bool> SaveAsync(Video video);
}