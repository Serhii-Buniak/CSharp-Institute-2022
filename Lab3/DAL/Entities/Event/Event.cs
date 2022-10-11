namespace DAL.Entities;

public class Event
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public long GalleryId { get; set; }
    public Gallery Gallery { get; set; } = null!;
    public long UserId { get; set; }
    public User User { get; set; } = null!;
    public long CityId { get; set; }
    public City City { get; set; } = null!;
}
