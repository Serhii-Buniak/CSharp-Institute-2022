using EventMicroService.Domain.Common;

namespace EventMicroService.Domain.Entities;

public class User : IdentifiedExternalEntity<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public City City { get; set; } = null!;
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
