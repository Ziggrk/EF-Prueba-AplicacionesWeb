using System.ComponentModel.DataAnnotations;
using Example.Infrastructure.Models;

namespace Example.API.Response;

public class VideoResponse
{
    public String Title { get; set; }
    public TimeSpan duration{ get; set; }
}