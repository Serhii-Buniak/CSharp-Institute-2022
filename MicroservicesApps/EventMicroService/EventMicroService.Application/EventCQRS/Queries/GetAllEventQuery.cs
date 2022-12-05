using AutoMapper;
using EventMicroService.Application.Common.Dtos;
using EventMicroService.Application.Common.Interfaces;
using EventMicroService.Application.Common.Mappings;
using MediatR;

namespace EventMicroService.Application.EventCQRS.Queries;

public class GetAllEventQuery : IRequest<IEnumerable<EventReadDto>>
{
    public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQuery, IEnumerable<EventReadDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEventQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventReadDto>> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events.ProjectToListAsync<EventReadDto>(_mapper.ConfigurationProvider);
        }
    }
}
