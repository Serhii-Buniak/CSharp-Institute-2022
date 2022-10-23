using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class ImageBlobService : IImageBlobService
{
    public const string ImageKey = "images";
    private readonly BlobServiceClient _storage;
    private readonly IApplicationDbContext _dbContext;

    public ImageBlobService(BlobServiceClient blobServiceClient, IApplicationDbContext applicationDbContext)
    {
        _storage = blobServiceClient;
        _dbContext = applicationDbContext;
    }

    public async Task<BlobData> GetByIdAsync(long id)
    {
        Image? image = await _dbContext.Images.FindAsync(id);

        if (image is null)
        {
            throw new NotFoundException(nameof(Image), id);
        }

        string fileName = image.Name;

        return await _storage.GetBlobAsync(ImageKey, fileName); 
    }

    public async Task UploadAsync(IFormFile file)
    {
        await _storage.UploadBlobAsync(ImageKey, file);
    }

    public async Task DeleteAsync(long id)
    {
        Image? image = await _dbContext.Images.FindAsync(id);

        if (image is null)
        {
            throw new NotFoundException(nameof(Image), id);
        }

        await _storage.DeleteBlobAsync(ImageKey, image.Name);
    }
}