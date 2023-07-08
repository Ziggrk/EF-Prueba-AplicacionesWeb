using Microsoft.AspNetCore.Mvc;

namespace Example.API.Request;

public class LeafRequest
{
    
    public String Title { get; set; }
    public String Scenario { get; set; }
    public int Tip { get; set; }
}