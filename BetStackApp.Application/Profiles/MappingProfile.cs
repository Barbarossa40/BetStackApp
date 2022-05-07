using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BetStackApp.Application.Features.Bets.Queries.GetBetsList;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetailDtos;
using BetStackApp.Domain.Entities;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorsList;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;
using BetStackApp.Application.Features.Sports.Queries.GetSportsList;
using BetStackApp.Application.Features.Leagues.Queries.GetLeaguesList;
using BetStackApp.Application.Features.Bets.Commands.CreateBet;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail.GetCompetitorDetailDtos;
using BetStackApp.Application.Features.Sports.Queries.GetSportDetails;
using BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor;


namespace BetStackApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Bet Details
            CreateMap<Sport, GetSportBetDto>().ReverseMap();
            CreateMap<League, GetLeagueBetDto>().ReverseMap();

            CreateMap<Competitor, GetBetCompetitorDto>()
                .ForMember(b => b.BetOn, opt => opt.MapFrom(b => b.CompetitorBets
                     .Select(bc => bc.BetOn)))
                .ReverseMap();


            // Bet List 
            CreateMap<Bet, BetsListVM>().ReverseMap();

            //Comp List might have to add mapping here and to bet list for league and competitors and sport
            CreateMap<Competitor, CompetitorsListVM>().ReverseMap();



            //comp detail
            CreateMap<Competitor, CompetitorDetailsVM>().ReverseMap();  
                //.ForMember(cb => cb.CompetitorBets, opt => opt.MapFrom(cb => cb.CompetitorBets
                //    .Select(b => b.Bet)))
                //.ReverseMap();

            CreateMap<Bet, GetCompetitorDetailBetDto>();

            CreateMap<Competitor, GetCompetitorDetailCompetitorsDto>()
                  .ForMember(b => b.BetOn, opt => opt.MapFrom(b => b.CompetitorBets
                     .Select(bc => bc.BetOn)))
                .ReverseMap();



            //sports
            CreateMap<Sport, SportsListVM>().ReverseMap();
            CreateMap<League, GetSportDetailsLeagueDto>().ReverseMap();


            //leagues
            CreateMap<League, LeaguesListVM>().ReverseMap();


            //BET command create
            CreateMap<CreateBetCommand, Bet>()
                 //.ForMember(b => b.BetCompetitors, opt => opt.MapFrom(b => b.BetCompetitors
                 //    .Select(bc => bc.BetOn)))
                .ReverseMap();

            CreateMap<CreatetBetCompetitorsDto, BetCompetitor>().ReverseMap();
                //.ForMember(name??)

                //the above should work but I need to work out how exaclty the incoming dto will be mapped and saved to the context. Do I even need the "name"
                // part of the Dto or can i just have the competitoreID?
            //this goes to Bet Creation and how to handle the incoming Icollection<BetCompetitors>


            // create comp
            CreateMap<Competitor, CreateCompetitorDto>().ReverseMap();
        }
    }
}
