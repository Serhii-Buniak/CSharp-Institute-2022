using AutoMapper;
using EventMicroService.Application.Common.Dtos;
using EventMicroService.Application.Common.Interfaces;
using EventMicroService.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EventMicroService.Application.EventCQRS.Commands;

public class UpdateEventCommand : IRequest<EventReadDto>
{
    protected long Id { get; set; }
    public string Name { get; set; } = null!;

    public void SetId(long id)
    {
        Id = id;
    }

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventReadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventReadDto> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = new() { Id = request.Id, Name = request.Name };

            _context.Events.Update(@event);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EventReadDto>(@event);
        }
    }

    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEventCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .Must(IsUniqueName);
        }

        private bool IsUniqueName(UpdateEventCommand image, string value)
        {
            return !_context.Events.Any(x => image.Name == x.Name);
        }
    }
}
