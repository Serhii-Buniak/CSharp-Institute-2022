﻿using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.ImageActions.Queries;

public class GetImagesQuery : IRequest<IEnumerable<ImageDto>>
{
    public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, IEnumerable<ImageDto>>
    {
        private readonly IApplicationDbContext _dataContext;
        private readonly IMapper _mapper;

        public GetImagesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dataContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageDto>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Images
                  .ProjectToListAsync<ImageDto>(_mapper.ConfigurationProvider);
        }
    }
}