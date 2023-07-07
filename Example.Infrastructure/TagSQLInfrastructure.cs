using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class TagSQLInfrastructure : ITagInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public TagSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Tag>> GetByVideoId(int videoId)
    {
        var tags = await exampleDbContext.Tags.Where(video => video.VideoObject.Id == videoId).ToListAsync();
        return tags;
    }

    public async Task<Tag> GetTagByName(String name)
    {
        var tag = await exampleDbContext.Tags.Where(tag => tag.Name == name).SingleOrDefaultAsync();
        return tag;
    }
}