using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorsList
{
    public class GetCompetitorListHandler: IRequestHandler<GetCompetitorListQuery, List<CompetitorsListVM>>
    {

        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;

        public GetCompetitorListHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
        }

        public async Task<List<CompetitorsListVM>> Handle(GetCompetitorListQuery request, CancellationToken cancellationToken)
        {
            var allCompetitors = (await _competitorRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CompetitorsListVM>>(allCompetitors);
        }
    }
}

//           // remember I need to make sure that when I return the list of Competitor that Sport,League, are included.
//           // Probs override method in repo implementation. Make sure mappings okay
