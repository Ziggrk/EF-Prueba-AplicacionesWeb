using AutoMapper;
using Example.API.Response;
using Example.Infrastructure.Models;

namespace Example.API.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Tag, TagResponse>();
        CreateMap<Video, VideoResponse>();
    }
}