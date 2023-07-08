using System.ComponentModel.DataAnnotations;
using Example.API.Request;

namespace Example.API.Response;

public class FarmerRequest
{
    [Required]
    public String Username { get; set; }
    [Required]
    public String Email { get; set; }
    [Required]
    public String FirstName { get; set; }
    [Required]
    public String LastName { get; set; }
    public List<FarmlandRequest> Farmlands { get; set; }
}