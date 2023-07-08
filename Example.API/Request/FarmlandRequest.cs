using Microsoft.Build.Framework;

namespace Example.API.Request;

public class FarmlandRequest
{
    [Required]
    public long Altitude { get; set; }
    [Required]
    public long Latitude { get; set; }
    [Required]
    public long Longitude { get; set; }
    [Required]
    public long Length { get; set; }
    [Required]
    public long Width { get; set; }
}