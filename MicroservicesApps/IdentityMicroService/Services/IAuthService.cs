using IdentityMicroService.Data;
using IdentityMicroService.Dtos;
using System.Net;

namespace IdentityMicroService.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto model);
    Task<AuthTokensDto> LogInAsync(LogInDto model, string? currRefreshToken);
    Task<AuthTokensDto> RefreshTokenAsync(string jwtToken);
    Task RevokeToken(string token);
}
