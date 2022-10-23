using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.ImageActions.Commands;

public class DeleteImageCommand : IRequest
{
    public DeleteImageCommand(long id)
    {
        Id = id;
    }

    public long Id { get; set; }

    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IApplicationDbContext _dataContext;
        private readonly IImageBlobService _blobService;

        public DeleteImageCommandHandler(IApplicationDbContext applicationDbContext, IImageBlobService imageBlobService)
        {
            _dataContext = applicationDbContext;
            _blobService = imageBlobService;
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            Image? image = await _dataContext.Images.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);

            if (image is null)
            {
                throw new NotFoundException(nameof(Image), request.Id);
            }

            await _blobService.DeleteAsync(image.Id);

            _dataContext.Images.Remove(image);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}