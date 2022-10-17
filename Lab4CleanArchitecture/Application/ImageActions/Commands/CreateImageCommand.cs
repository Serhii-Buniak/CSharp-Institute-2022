using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.ImageActions.Commands;

public class CreateImageCommand : IRequest<ImageDto>
{
    public string Name { get; set; } = null!;
    public long? GalleryId { get; set; } = null;

    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageDto>
    {
        private readonly IApplicationDbContext _dataContext;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dataContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<ImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            Image image = new()
            {
                Name = request.Name,
                GalleryId = request.GalleryId
            };

            await _dataContext.Images.AddAsync(image, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ImageDto>(image); ;
        }
    }

    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        private readonly IApplicationDbContext _dataContext;

        public CreateImageCommandValidator(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300)
                .Must(IsUniqueName).WithMessage(x => $"Image with '{x.Name}' Name already exist");
        }

        private bool IsUniqueName(CreateImageCommand image, string value)
        {
            return !_dataContext.Images.Any(x => image.Name == x.Name);
        }
    }
}