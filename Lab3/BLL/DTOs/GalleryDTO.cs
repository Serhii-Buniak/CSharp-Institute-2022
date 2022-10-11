namespace BLL.DTOs;

public class GalleryDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<ImageDTO> Images { get; set; } = Enumerable.Empty<ImageDTO>();
}
