using EventMicroService.Application.Common.Mappings;
using EventMicroService.Domain.Entities;

namespace EventMicroService.Application.Common.Dtos;

public class EventReadDto : IMapFrom<Event>
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<CategoryReadDto> Categories { get; set; } = null!;
}
