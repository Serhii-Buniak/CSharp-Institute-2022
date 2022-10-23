﻿using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.ImageActions.Commands;

public class CreateImageCommand : IRequest<ImageDto>
{
    public IFormFile File { get; set; } = null!;
    public long? GalleryId { get; set; } = null;

    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageDto>
    {
        private readonly IApplicationDbContext _dataContext;
        private readonly IImageBlobService _blobService;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IApplicationDbContext applicationDbContext, IImageBlobService imageBlobService, IMapper mapper)
        {
            _dataContext = applicationDbContext;
            _blobService = imageBlobService;
            _mapper = mapper;
        }

        public async Task<ImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            Image image = new()
            {
                Name = request.File.FileName,
                GalleryId = request.GalleryId
            };

            await _blobService.UploadAsync(request.File);

            await _dataContext.Images.AddAsync(image, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ImageDto>(image);
        }
    }

    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        private readonly IApplicationDbContext _dataContext;

        public CreateImageCommandValidator(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.File)
                .NotNull();

            RuleFor(x => x.File.FileName)
                .NotEmpty()
                .MaximumLength(300)
                .Must(IsUniqueName).WithMessage(x => $"Image with '{x.File.FileName}' Name already exist");
        }

        private bool IsUniqueName(CreateImageCommand image, string value)
        {
            return !_dataContext.Images.Any(x => image.File.FileName == x.Name);
        }
    }
}