using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class LeafSQLInfrastructure : ILeafInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public LeafSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Leaf>> GetByTreeId(int id)
    {
        var leafs = await exampleDbContext.Leafs.Where(leaf => leaf.Tree.Id == id).ToListAsync();
        return leafs;
    }

    public async Task<bool> SaveAsync(Leaf leaf)
    {
        await exampleDbContext.Leafs.AddAsync(leaf);
        await exampleDbContext.SaveChangesAsync();
        return true;
    }
}