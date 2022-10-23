using Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IImageBlobService
    {
        Task<BlobData> GetByIdAsync(long id);
        Task UploadAsync(IFormFile file);
        Task DeleteAsync(long id);
    }
}