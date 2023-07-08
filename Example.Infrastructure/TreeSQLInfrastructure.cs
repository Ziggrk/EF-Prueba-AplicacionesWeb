using Example.Infrastructure.Context;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class TreeSQLInfrastructure : ITreeInfrastructure
{
    private ExampleDbContext exampleDbContext;

    public TreeSQLInfrastructure(ExampleDbContext exampleDbContext)
    {
        this.exampleDbContext = exampleDbContext;
    }

    public async Task<List<Tree>> GetAllAsync()
    {
        var trees = await exampleDbContext.Trees.ToListAsync();
        return trees;
    }

    public async Task<Tree?> GetByUsername(String username)
    {
        var tree = await exampleDbContext.Trees.FirstOrDefaultAsync(tree => tree.Username == username);
        return tree;
    }

    public async Task<Tree?> GetByIdAsync(int id)
    {
        var tree = await exampleDbContext.Trees.FindAsync(id);
        return tree;
    }

    public async Task<bool> SaveAsync(Tree tree)
    {
        await exampleDbContext.Trees.AddAsync(tree);
        await exampleDbContext.SaveChangesAsync();
        return true;
    }
}