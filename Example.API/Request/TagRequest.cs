using System.ComponentModel.DataAnnotations;

namespace Example.API.Request;

public class TagRequest
{
    [Required]
    [MinLength(5)]
    public String Name { get; set; }
}