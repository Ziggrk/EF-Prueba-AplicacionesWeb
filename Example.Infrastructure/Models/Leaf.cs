namespace Example.Infrastructure.Models;

public class Leaf
{
    public int Id { get; set; }
    public String Title { get; set; }
    public String Scenario { get; set; }
    public int Tip { get; set; }
    public Tree? Tree { get; set; }
}