using Microsoft.AspNetCore.Identity;

namespace IdentityMicroService.BLL.DAL.Data;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public City City { get; set; } = null!;
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
