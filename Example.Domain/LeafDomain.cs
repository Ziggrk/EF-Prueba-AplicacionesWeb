using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;

namespace Example.Domain;

public class LeafDomain : ILeafDomain
{
    private ILeafInfrastructure leafInfrastructure;

    public LeafDomain(ILeafInfrastructure leafInfrastructure)
    {
        this.leafInfrastructure = leafInfrastructure;
    }

    public Task<bool> SaveAsync(Leaf leaf)
    {
        if(!IsTitleUnique(leaf))
            throw new Exception("A leaf with the same title already exists for the same tree.");
        return leafInfrastructure.SaveAsync(leaf);
    }

    private bool IsTitleUnique(Leaf leaf)
    {
        var leafs = leafInfrastructure.GetByTreeId(leaf.Tree.Id);
        bool hasDuplicateTitle = leafs.Result.Any(l => l.Title == leaf.Title);

        return !hasDuplicateTitle;
    }

}