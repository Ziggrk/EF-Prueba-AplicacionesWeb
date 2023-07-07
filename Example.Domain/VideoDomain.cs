using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;

namespace Example.Domain;

public class VideoDomain : IVideoDomain
{
    private IVideoInfrastructure videoInfrastructure;
    private ITagInfrastructure tagInfrastructure;

    public VideoDomain(IVideoInfrastructure videoInfrastructure, ITagInfrastructure tagInfrastructure)
    {
        this.videoInfrastructure = videoInfrastructure;
        this.tagInfrastructure = tagInfrastructure;
    }

    public Task<bool> SaveAsync(Video video)
    {
        if(!IsValidLenght(video))
            throw new Exception("must follow the user format");
        if (!AreTagsNameUnique(video))
            throw new Exception("tags names are not unique");
        return videoInfrastructure.SaveAsync(video);
    }

    private bool IsValidLenght(Video video)
    {
        int minLenght = 5;
        return video.Title.Length > minLenght;
    }

    private bool AreTagsNameUnique(Video video)
    {
        var distinctTags = video.Tags.Select(tag => tag.Name).Distinct();
        return video.Tags.Count == distinctTags.Count();
    }
}