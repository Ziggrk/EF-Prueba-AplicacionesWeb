namespace Example.Infrastructure.Models;

public class Farmland
{
    public int Id { get; set; }
    public long Altitude { get; set; }
    public long Latitude { get; set; }
    public long Longitude { get; set; }
    public long Length { get; set; }
    public long Width { get; set; }
    public Farmer Farmer { get; set; }
}