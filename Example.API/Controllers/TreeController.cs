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
public class TreeController : ControllerBase
{
    private ILeafDomain leafDomain;
    private ILeafInfrastructure leafInfrastructure;
    private ITreeDomain treeDomain;
    private ITreeInfrastructure treeInfrastructure;
    private IMapper mapper;

    public TreeController(ILeafDomain leafDomain, ILeafInfrastructure leafInfrastructure, ITreeDomain treeDomain, ITreeInfrastructure treeInfrastructure, IMapper mapper)
    {
        this.leafDomain = leafDomain;
        this.leafInfrastructure = leafInfrastructure;
        this.treeDomain = treeDomain;
        this.treeInfrastructure = treeInfrastructure;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<List<TreeResponse>> GetAll()
    {
        var result = await treeInfrastructure.GetAllAsync();
        var list =  mapper.Map<List<Tree>, List<TreeResponse>>(result);

        return list;
    }
    
    [HttpPost] 
    public async Task<IActionResult> PostAsync([FromBody] TreeResquest input) 
    { 
        if (ModelState.IsValid) 
        { 
            var tree = mapper.Map<TreeResquest, Tree>(input); 
            var result = await treeDomain.SaveAsync(tree);
             
            return  result ? StatusCode(201) : StatusCode(500);
        }
        else
        {
            return StatusCode(400);
        }
    }
    
    [HttpGet("{id}/Leaf")]
    public async Task<List<LeafResponse>> GetLeafsByTreeId(int id)
    {
        var result = await leafInfrastructure.GetByTreeId(id);
        var list =  mapper.Map<List<Leaf>, List<LeafResponse>>(result);

        return list;
    }
    
    [HttpPost("{id}/Leaf")]
    public async Task<IActionResult> PostLeafAsync([FromBody] LeafRequest input, int id) 
    { 
        if (ModelState.IsValid)
        {
            var tree = treeInfrastructure.GetByIdAsync(id);
            if (tree == null)
                throw new Exception("A tree with that id doesnt exists.");
            var leaf = mapper.Map<LeafRequest, Leaf>(input);
            leaf.Tree = await tree;
            var result = await leafDomain.SaveAsync(leaf);
             
            return  result ? StatusCode(201) : StatusCode(500);
        }
        else
        {
            return StatusCode(400);
        }
    }
}