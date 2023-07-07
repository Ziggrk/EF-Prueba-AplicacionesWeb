using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface IVideoInfrastructure
{
    Task<List<Video>> GetAllAsync();
    public Task<bool> SaveAsync(Video video);
}