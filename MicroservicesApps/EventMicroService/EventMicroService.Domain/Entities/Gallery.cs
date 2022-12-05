using EventMicroService.Domain.Common;

namespace EventMicroService.Domain.Entities;

public class Gallery : IdentifiedExternalEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = new List<Image>();

}
