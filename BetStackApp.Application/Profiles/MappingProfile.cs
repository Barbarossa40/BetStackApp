using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BetStackApp.Application.Features.Bets.Queries.GetBetsList;
using BetStackApp.Application.Features.Bets.dtos;
using BetStackApp.Domain.Entities;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorsList;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;
using BetStackApp.Application.Features.Sports.Queries.GetSportsList;
using BetStackApp.Application.Features.Leagues.Queries.GetLeaguesList;
using BetStackApp.Application.Features.Bets.Commands.CreateBet;
using BetStackApp.Application.Features.Bets.Commands.CreateBet.CreateBetDtos;

namespace BetStackApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Bet Details
            CreateMap<Sport, SportDto>().ReverseMap();
            CreateMap<League, LeagueDto>().ReverseMap();

            CreateMap<Competitor, BetCompetitorDto>()
                .ForMember(b => b.BetOn, opt => opt.MapFrom(b => b.CompetitorBets
                     .Select(bc => bc.BetOn)))
                .ReverseMap();


            // Bet List 
            CreateMap<Bet, BetsListVM>().ReverseMap();

            //Comp List might have toi add mapping here and to bet list for league and competitors and sport
            CreateMap<Competitor, CompetitorsListVM>().ReverseMap();
         


            //comp detail
            CreateMap<Competitor, CompetitorDetailsVM>()
                .ForMember(cb => cb.BetCompetitor, opt => opt.MapFrom(cb => cb.CompetitorBets
                    .Select(b => b.Bet)))
                .ReverseMap();


            CreateMap<Bet, CompetitorBetDto>()
                .ForMember(bc => bc.BetCompetitors, opt => opt.MapFrom(bc => bc.BetCompetitors
                    .Select(C => C.Competitor)))
                .ReverseMap();

            //sports
            CreateMap<Sport, SportsListVM>().ReverseMap();


            //leagues
            CreateMap<League, LeaguesListVM>().ReverseMap();


            //bet command create
            CreateMap<Bet, CreateBetCommand>().ReverseMap();
            CreateMap<Sport,CreateBetSportDto>().ReverseMap();
            CreateMap<League,CreateBetLeagueDto>().ReverseMap();
            CreateMap<Competitor, CreatetBetCompetitorsDto>()
                .ForMember(b => b.BetOn, opt => opt.MapFrom(b => b.CompetitorBets
                     .Select(bc => bc.BetOn)))
                .ReverseMap();

        }
    }
}
