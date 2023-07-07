namespace Example.Infrastructure.Models;

public class Video 
{
    public int Id { get; set; }
    public String Title { get; set; }
    public TimeSpan duration{ get; set; }
    public List<Tag> Tags { get; set; }
}