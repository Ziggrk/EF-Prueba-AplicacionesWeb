using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface IVideoInfrastructure
{
    Task<List<Video>> GetAllAsync();
    Task<bool> SaveAsync(Video video);
}