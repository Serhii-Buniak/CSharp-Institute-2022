using IdentityMicroService.Dtos;

namespace IdentityMicroService.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid id);
}