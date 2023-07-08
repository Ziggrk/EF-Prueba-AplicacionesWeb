using AutoMapper;
using Example.API.Request;
using Example.Infrastructure.Models;

namespace Example.API.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<TagRequest, Tag>();
        CreateMap<VideoRequest, Video>();
        CreateMap<LeafRequest, Leaf>();
        CreateMap<TreeResquest, Tree>();
    }

}