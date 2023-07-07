namespace Example.Infrastructure.Models;

public class Tag
{
    public int Id { get; set; }
    public String Name { get; set; }
    public Video VideoObject { get; set; }
}