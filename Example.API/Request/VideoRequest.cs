using System.ComponentModel.DataAnnotations;
using Example.Infrastructure.Models;

namespace Example.API.Request;

public class VideoRequest
{
    [Required]
    [MinLength(5)]
    public String Title { get; set; }
    [Required]
    public TimeSpan duration{ get; set; }
    public List<TagRequest> Tags { get; set; }
}