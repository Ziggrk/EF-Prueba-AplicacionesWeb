namespace Example.API.Response;

public class TreeResponse
{
    public String Username { get; set; }
    public String Email { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Gender { get; set; }
    public DateOnly BornAt { get; set; }
}