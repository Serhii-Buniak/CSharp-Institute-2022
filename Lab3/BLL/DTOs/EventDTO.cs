namespace BLL.DTOs;

public class EventDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<CategoryDTO> Categories { get; set; } = Enumerable.Empty<CategoryDTO>();
    public GalleryDTO Gallery { get; set; } = null!;
    public UserDTO User { get; set; } = null!;
    public CityDTO City { get; set; } = null!;
}
