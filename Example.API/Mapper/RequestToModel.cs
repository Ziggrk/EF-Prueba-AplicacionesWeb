using AutoMapper;
using Example.API.Request;
using Example.API.Response;
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
        CreateMap<FarmerRequest, Farmer>();
        CreateMap<FarmlandRequest, Farmland>();
    }

}