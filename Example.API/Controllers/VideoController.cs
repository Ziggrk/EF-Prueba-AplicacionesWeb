using AutoMapper;
using Example.API.Request;
using Example.API.Response;
using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
     //Inyeccion
     private IVideoInfrastructure videoInfrastructure;
     private IVideoDomain videoDomain;
     private ITagInfrastructure tagInfrastructure;
     private IMapper mapper;

     public VideoController(ITagInfrastructure tagInfrastructure, IMapper mapper, IVideoDomain videoDomain, IVideoInfrastructure videoInfrastructure)
     {
         this.tagInfrastructure = tagInfrastructure;
         this.mapper = mapper;
         this.videoDomain = videoDomain;
         this.videoInfrastructure = videoInfrastructure;
     }

     // GET: api/Video
     [HttpGet]
     public async Task<List<VideoResponse>> GetAll()
     {
         var result = await videoInfrastructure.GetAllAsync();
         var list =  mapper.Map<List<Video>, List<VideoResponse>>(result);

         return list;
     }
        
     [HttpGet("{id}/Tag")]
     public async Task<List<TagResponse>> GetTagsByVideoId(int id)
     {
         var result = await tagInfrastructure.GetByVideoId(id);
         var list =  mapper.Map<List<Tag>, List<TagResponse>>(result);

         return list;
     }

     // POST: api/Tutorial
     [HttpPost] 
     public async Task<IActionResult> PostAsync([FromBody] VideoRequest input) 
     { 
         if (ModelState.IsValid) 
         { 
             var video = mapper.Map<VideoRequest, Video>(input); 
             var result = await videoDomain.SaveAsync(video);
             
             return  result ? StatusCode(201) : StatusCode(500);
         }
         else
         {
             return StatusCode(400);
         }
     }
}