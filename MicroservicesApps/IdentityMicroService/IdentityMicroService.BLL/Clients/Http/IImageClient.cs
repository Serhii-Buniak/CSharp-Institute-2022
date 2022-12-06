using Microsoft.AspNetCore.Http;

namespace IdentityMicroService.BLL.Clients.Http;

public interface IImageClient
{
    Task CreateImage(IFormFile image);
}
