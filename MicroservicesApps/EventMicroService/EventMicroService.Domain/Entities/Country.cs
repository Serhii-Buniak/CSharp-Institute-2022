using EventMicroService.Domain.Common;

namespace EventMicroService.Domain.Entities;

public class Country : IdentifiedExternalEntity
{
    public string Name { get; set; } = null!;
    public ICollection<City> Cities { get; set; } = new List<City>();

}