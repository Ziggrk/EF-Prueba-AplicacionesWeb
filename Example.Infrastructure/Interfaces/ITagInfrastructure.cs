using Example.Infrastructure.Models;

namespace Example.Infrastructure.Interfaces;

public interface ITagInfrastructure
{
    Task<List<Tag>> GetByVideoId(int videoId);
    Task<Tag> GetTagByName(String name);
}