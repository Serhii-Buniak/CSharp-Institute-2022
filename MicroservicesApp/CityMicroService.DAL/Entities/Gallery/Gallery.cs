namespace CityMicroService.DAL.Entities;

public class Gallery
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
