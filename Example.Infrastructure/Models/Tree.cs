namespace Example.Infrastructure.Models;

public class Tree
{
    public int Id { get; set; }
    public String Username { get; set; }
    public String Email { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Gender { get; set; }
    public DateOnly BornAt { get; set; }
    public List<Leaf> Leafs { get; set; }
}