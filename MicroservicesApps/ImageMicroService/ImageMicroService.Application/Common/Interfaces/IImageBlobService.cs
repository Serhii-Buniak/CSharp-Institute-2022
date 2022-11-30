using ImageMicroService.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace ImageMicroService.Application.Common.Interfaces
{
    public interface IImageBlobService
    {
        Task<BlobData> GetByIdAsync(long id);
        Task UploadAsync(IFormFile file);
        Task DeleteAsync(long id);
    }
}