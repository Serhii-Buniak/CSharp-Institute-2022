using EventMicroService.Domain.Common;

namespace EventMicroService.Domain.Entities;

public class Image : IdentifiedExternalEntity
{
    public string Name { get; set; } = null!;
    public long GalleryId { get; set; }
    public Gallery Gallery { get; set; } = null!;
}
