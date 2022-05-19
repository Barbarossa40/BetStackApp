using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorList
{
    public class GetCompetitorListHandler: IRequestHandler<GetCompetitorListQuery, List<CompetitorListVm>>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Competitor> _competitorRepository;

        public GetCompetitorListHandler(IMapper mapper, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _competitorRepository = competitorRepository;
        }

        public async Task<List<CompetitorListVm>> Handle(GetCompetitorListQuery request, CancellationToken cancellationToken)
        {
            var allCompetitors = (await _competitorRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CompetitorListVm>>(allCompetitors);
        }
    }
}


