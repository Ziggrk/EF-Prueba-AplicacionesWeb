namespace Example.Infrastructure.Models;

public class Farmer
{
    public int Id { get; set; }
    public String Username { get; set; }
    public String Email { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public List<Farmland> Farmlands { get; set; }
}