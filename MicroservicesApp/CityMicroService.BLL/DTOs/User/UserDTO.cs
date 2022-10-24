namespace CityMicroService.BLL.DTOs;

public class UserDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public CityDTO City { get; set; } = null!;
    public IEnumerable<RoleDTO> Roles { get; set; } = Enumerable.Empty<RoleDTO>();
    public IEnumerable<MessageDTO> Messages { get; set; } = Enumerable.Empty<MessageDTO>();
}
