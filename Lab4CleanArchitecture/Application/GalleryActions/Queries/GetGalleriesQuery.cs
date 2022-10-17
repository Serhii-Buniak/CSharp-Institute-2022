using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.GalleryActions.Queries;

public class GetGalleriesQuery : IRequest<IEnumerable<GalleryDto>>
{
    public class GetGalleriesQueryHandler : IRequestHandler<GetGalleriesQuery, IEnumerable<GalleryDto>>
    {
        private readonly IApplicationDbContext _dataContext;
        private readonly IMapper _mapper;

        public GetGalleriesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dataContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GalleryDto>> Handle(GetGalleriesQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Galleries
                  .Include(g => g.Images)
                  .ProjectToListAsync<GalleryDto>(_mapper.ConfigurationProvider);
        }
    }
}