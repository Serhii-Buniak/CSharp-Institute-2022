using System.Text.Json.Serialization;

namespace IdentityMicroService.Dtos;

public class AuthTokensDto
{
    public string Token { get; set; } = null!;
    public RefreshTokenDto? RefreshToken { get; set; }
}
