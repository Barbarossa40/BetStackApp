using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BetStackApp.Domain.Entities;
using BetStackApp.Application.Features.Bets.Queries.GetBetList;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetail.GetBetDetailDtos;
using BetStackApp.Application.Features.Parlays.Queries.GetParlayList;
using BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetail;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorList;
using BetStackApp.Application.Features.Bets.Commands.CreateBet;
using BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor;
using BetStackApp.Application.Features.Matches.Commands;
using BetStackApp.Application.Features.Parlays.Commands.CreateParlay;

namespace BetStackApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //bet

            CreateMap<Bet, BetListVm>()
                .ForMember(e => e.MatchEventName, opt => opt.MapFrom(m => m.MatchBetOn.MatchEventName))
                .ForMember(n => n.BetOn, opt => opt.MapFrom(c => c.BetOn.Name))
                .ForMember(n => n.BetAgainst, opt => opt.MapFrom(c => c.BetAgainst.Name))
                .ReverseMap(); //probably shouldnt reverse map here

            CreateMap<Bet, BetDetailVm>().ReverseMap();

            CreateMap<Match, MatchDto>().ReverseMap();

            CreateMap<Competitor, CompetitorDto>().ReverseMap();

            //competitor

            CreateMap<Competitor, CompetitorListVm>().ReverseMap();

            CreateMap<Competitor,CompetitorDetailVm>().ReverseMap();


            //parlay
            CreateMap<Parlay,ParlayListVm>()
                .ForMember(bc=>bc.BetOnCompetitors, opt=>opt.MapFrom(pb=>pb.ParlayBets.Select(c=>c.BetOn.Name))).ReverseMap();

            

            CreateMap<Parlay, ParlayDetailVm>().ReverseMap();

            CreateMap<Bet, BetDto>().ReverseMap();

            //CreateBetCommand

            CreateMap<Bet, CreateBetCommand>().ReverseMap();


            //Create Competitor

            CreateMap<Competitor, CreateCompetitorDto>().ReverseMap();


            //create Match
            CreateMap<Match, CreateMatchDto>().ReverseMap();


            //create Parlay
            CreateMap<CreateParlayCommand, Parlay>()
                .ForMember(pb => pb.ParlayBets, opt => opt.Ignore()).ReverseMap();
                







            ////leagues
            //CreateMap<League, LeaguesListVM>().ReverseMap();


            ////BET command create
            //CreateMap<CreateBetCommand, Bet>()
            //     //.ForMember(b => b.BetCompetitors, opt => opt.MapFrom(b => b.BetCompetitors
            //     //    .Select(bc => bc.BetOn)))
            //    .ReverseMap();

            //CreateMap<CreatetBetCompetitorsDto, BetCompetitor>().ReverseMap();
            //    //.ForMember(name??)

            //    //the above should work but I need to work out how exaclty the incoming dto will be mapped and saved to the context. Do I even need the "name"
            //    // part of the Dto or can i just have the competitoreID?
            ////this goes to Bet Creation and how to handle the incoming Icollection<BetCompetitors>


            //// create comp
            //CreateMap<Competitor, CreateCompetitorDto>().ReverseMap();
        }
    }
}
