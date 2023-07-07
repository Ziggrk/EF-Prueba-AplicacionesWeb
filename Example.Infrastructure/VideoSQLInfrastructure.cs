using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class VideoSQLInfrastructure : IVideoInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public VideoSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Video>> GetAllAsync()
    {
        var videos = await exampleDbContext.Videos.ToListAsync();
        return videos;
    }

    public async Task<bool> SaveAsync(Video video)
    {
        await exampleDbContext.Videos.AddAsync(video);
        await exampleDbContext.SaveChangesAsync();
        return true;
    }
}