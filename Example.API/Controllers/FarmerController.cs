using AutoMapper;
using Example.API.Response;
using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FarmerController : ControllerBase
{
         //Inyeccion
         private IFarmerInfrastructure farmerInfrastructure;
         private IFarmlandInfrastructure farmlandInfrastructure;
         private IFarmerDomain farmerDomain;
         private IMapper mapper;

         public FarmerController(IFarmerDomain farmerDomain, IMapper mapper, IFarmlandInfrastructure farmlandInfrastructure, IFarmerInfrastructure farmerInfrastructure)
         {
             this.farmerDomain = farmerDomain;
             this.mapper = mapper;
             this.farmlandInfrastructure = farmlandInfrastructure;
             this.farmerInfrastructure = farmerInfrastructure;
         }


         // GET: api/Farmer
         [HttpGet]
         public async Task<List<FarmerResponse>> GetAll()
         {
             var result = await farmerInfrastructure.GetAllAsync();
             var list =  mapper.Map<List<Farmer>, List<FarmerResponse>>(result);
    
             return list;
         }
            
         [HttpGet("{id}/Farmland")]
         public async Task<List<FarmlandResponse>> GetFarmlandByFarmerId(int id)
         {
             var result = await farmlandInfrastructure.GetByFarmerId(id);
             var list =  mapper.Map<List<Farmland>, List<FarmlandResponse>>(result);
    
             return list;
         }
    
         // POST: api/Farmer
         [HttpPost] 
         public async Task<IActionResult> PostAsync([FromBody] FarmerRequest input) 
         { 
             if (ModelState.IsValid) 
             { 
                 var farmer = mapper.Map<FarmerRequest, Farmer>(input); 
                 var result = await farmerDomain.SaveAsync(farmer);
                 
                 return  result ? StatusCode(201) : StatusCode(500);
             }
             else
             {
                 return StatusCode(400);
             }
         }
}