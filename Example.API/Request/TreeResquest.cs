using System.ComponentModel.DataAnnotations;

namespace Example.API.Request;

public class TreeResquest
{
    [Required]
    public String Username { get; set; }
    [Required]
    public String Email { get; set; }
    [Required]
    public String FirstName { get; set; }
    [Required]
    public String LastName { get; set; }
    [Required]
    public String Gender { get; set; }
    [Required]
    public DateOnly BornAt { get; set; }
}