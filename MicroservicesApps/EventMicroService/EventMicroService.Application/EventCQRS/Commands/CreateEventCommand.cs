using AutoMapper;
using EventMicroService.Application.CategoryCQRS.Commands;
using EventMicroService.Application.Common.Dtos;
using EventMicroService.Application.Common.Interfaces;
using EventMicroService.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EventMicroService.Application.EventCQRS.Commands;

public class CreateEventCommand : IRequest<EventReadDto>
{
    public string Name { get; set; } = null!;

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventReadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventReadDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = new() { Name = request.Name };

            await _context.Events.AddAsync(@event, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EventReadDto>(@event);
        }
    }

    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateEventCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .Must(IsUniqueName);
        }

        private bool IsUniqueName(CreateEventCommand image, string value)
        {
            return !_context.Events.Any(x => image.Name == x.Name);
        }
    }
}
