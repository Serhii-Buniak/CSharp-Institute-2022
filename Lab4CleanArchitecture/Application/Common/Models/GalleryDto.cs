using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Models;

public class GalleryDto : IMapFrom<Gallery>
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<ImageDto> Images { get; set; } = Enumerable.Empty<ImageDto>();
}