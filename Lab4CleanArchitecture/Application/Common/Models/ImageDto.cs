using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Models;

public class ImageDto : IMapFrom<Image>
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public long? GalleryId { get; set; }
}