using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Features.Bets.dtos;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class GetCompetitorDetailsQueryHandler : IRequestHandler<GetCompetitorDetailsQuery,CompetitorDetailsVM>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IAsyncRepository<BetCompetitor> _betCompetitorRepository;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;
        private readonly IMapper _mapper;

        public GetCompetitorDetailsQueryHandler(IMapper mapper, IAsyncRepository<BetCompetitor> betCompetitorRepository, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _betCompetitorRepository = betCompetitorRepository;
        }

        public async Task<CompetitorDetailsVM> Handle(GetCompetitorDetailsQuery request, CancellationToken cancellation)
        {
            var competitor = await _competitorRepository.GetByIdAsync(request.CompetitorId);
            var competitorDetailDto = _mapper.Map<CompetitorDetailsVM>(competitor);

            var sport = await _sportRepository.GetByIdAsync(competitor.Sport.SportId);
            competitorDetailDto.Sport = _mapper.Map<SportDto>(sport);

            var league = await _leagueRepository.GetByIdAsync(competitor.League.LeagueId);
            competitorDetailDto.League = _mapper.Map<LeagueDto>(league);

            var betMember = await _betRepository.GetListByIdAsync(request.CompetitorId);
            competitorDetailDto.BetCompetitor = _mapper.Map<List<CompetitorBetDto>>(betMember);


            return competitorDetailDto;
        }
    }
}


//config = new MapperConfiguration(cfg => {
//    cfg.CreateMap<User, UserViewModel>()
//    //This is actually unnecesseray
//    //.ForMember(m => m.UserId,opt =>opt.MapFrom(entity => entity.UserId))
//    // If you only want the first parent name - Not sure on structure of UserParent class so just assuming you have a field "Name"
//    .ForMember(vm => vm.UserParentName,
//               opt => opt.MapFrom(entity => entity.UserParents.FirstOrDefault().Name))
//    .ReverseMap();
//});

//IMapper mapper = config.CreateMapper();


//        List<Guid> compIdGuid = new List<Guid>();
//        foreach (var item in bet.BetCompetitors)
//        {
//            compIdGuid.Add(item.CompetitorId);
//        }
//        var competitors = await _competitorRepository.GetListByIdsAsync(compIdGuid);

//        betDetailDto.BetCompetitors = _mapper.Map<ICollection<BetCompetitorDto>>(competitors);


//        return betDetailDto;