using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;

namespace Example.Domain;

public class TreeDomain : ITreeDomain
{
    private ITreeInfrastructure treeInfrastructure;

    public TreeDomain(ITreeInfrastructure treeInfrastructure)
    {
        this.treeInfrastructure = treeInfrastructure;
    }

    public Task<bool> SaveAsync(Tree tree)
    {
        if(!IsUsernameUnique(tree))
            throw new Exception("A tree with the same username already exists.");
        if (!IsValidAge(tree))
            throw new Exception("A tree is not older than 50.");
        return treeInfrastructure.SaveAsync(tree);
    }

    private bool IsUsernameUnique(Tree tree)
    {
        var existingTree = treeInfrastructure.GetByUsername(tree.Username);
        if (existingTree == null)
            return false;
        return true;
    }

    private bool IsValidAge(Tree tree)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        DateOnly minimumAgeDate = today.AddYears(-50);

        return tree.BornAt < minimumAgeDate;
    }
}