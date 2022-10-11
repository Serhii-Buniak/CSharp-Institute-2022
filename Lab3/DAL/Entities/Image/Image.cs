namespace DAL.Entities;

public class Image
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public long? GalleryId { get; set; }
    public Gallery? Gallery { get; set; }
}
