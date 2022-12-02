using AutoMapper;
using IdentityMicroService.DAL.Data;
using IdentityMicroService.Dtos;
using IdentityMicroService.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityMicroService.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        IEnumerable<ApplicationUser> users = await _userManager.Users.Include(u => u.City).ToListAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        ApplicationUser? user = await _userManager.Users.Include(u => u.City).FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
        {
            throw new NotFoundException(nameof(ApplicationUser), id);
        }

        return _mapper.Map<UserDto>(user);
    }
}
