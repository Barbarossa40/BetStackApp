using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class GetCompetitorDetailsQueryHandler : IRequestHandler<GetCompetitorDetailsQuery,CompetitorDetailVm>
    {
        private readonly IAsyncRepository<Competitor> _competitorRepository;
        private readonly IMapper _mapper;

        public GetCompetitorDetailsQueryHandler(IMapper mapper, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _competitorRepository = competitorRepository;
        }

        public async Task<CompetitorDetailVm> Handle(GetCompetitorDetailsQuery request, CancellationToken cancellation)
        {
            var competitor = await _competitorRepository.GetByIdAsync(request.CompetitorId);
            var competitorDetailDto = _mapper.Map<CompetitorDetailVm>(competitor);
            

            return competitorDetailDto;
        }
    }
}


