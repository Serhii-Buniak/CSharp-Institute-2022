using EventMicroService.Domain.Common;

namespace EventMicroService.Domain.Entities;

public class City : IdentifiedExternalEntity
{
    public string Name { get; set; } = null!;
    public Country Country { get; set; } = null!;
}
