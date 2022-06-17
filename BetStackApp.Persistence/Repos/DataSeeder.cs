using BetStackApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Persistence.Repos
{
    public class DataSeeder
    {
        private readonly BetStackAppDbContext betStackAppDb;

        public DataSeeder(BetStackAppDbContext BetStackAppDb)
        {
            betStackAppDb = BetStackAppDb;
        }


        public void Seed()
        {
            //competitor seed
            if (!betStackAppDb.Competitors.Any() || !betStackAppDb.Bets.Any())
            {

                var competitorGuidOne = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
                var competitorGuidTwo = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
                var competitorGuidThree = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
                var competitorList = new List<Competitor>();

                var competitorOne = new Competitor
                {
                    CompetitorId = competitorGuidOne,
                    Name = "Geoffrey Charles",
                    HomeBase = "Lake Orion, MI USA",
                    Description = "According to his mother he is, a very handsome man"
                };
                competitorList.Add(competitorOne);

                var competitorTwo = new Competitor
                {
                    CompetitorId = competitorGuidTwo,
                    Name = "Chrissy Gentry",
                    HomeBase = "Lake Orion, MI USA",
                    Description = "As fierce and cute as the day is long"
                };
                competitorList.Add(competitorTwo);

                var competitorThree = new Competitor
                {
                    CompetitorId = competitorGuidThree,
                    Name = "Finn",
                    HomeBase = "Lake Orion, MI USA",
                    Description = "He's the Chunkiest boy but also the bestest"
                };

                competitorList.Add(competitorThree);  

                betStackAppDb.Competitors.AddRange(competitorList);

                betStackAppDb.SaveChanges();


                //Match Seed
                var matchGuidOne = Guid.Parse("{F4A6A3A0-4227-4973-ABB5-A63FBE725924}");
                var matchGuidTwo = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}");
                var matchGuidThree = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

                var matchList =new List<Match>();

                var matchOne = new Match
                {
                    MatchId = matchGuidOne,
                    MatchEventName = "The Rumble From Down Under: Chrissy vs. Geoffrey",
                    MatchDate = DateTime.Now,
                    Sport = "Mixed Martial Arts",
                    League = "LOBO Fight Club"
                };

                matchList.Add(matchOne);    

                var matchTwo = new Match
                {
                    MatchId = matchGuidTwo,
                    MatchEventName = "The Rumble From Down Under: Finn vs. Geoffrey",
                    MatchDate = DateTime.Now,
                    Sport = "Mixed Martial Arts",
                    League = "LOBO Fight Club"
                };

                matchList.Add(matchTwo);

                var matchThree = new Match
                {
                    MatchId = matchGuidThree,
                    MatchEventName = "The Rumble From Down Under: Chrissy vs. Finn",
                    MatchDate = DateTime.Now,
                    Sport = "Mixed Martial Arts",
                    League = "LOBO Fight Club"
                };

                matchList.Add(matchThree);

                betStackAppDb.Matches.AddRange(matchList);

                betStackAppDb.SaveChanges();

                // Bet Seed

                var betGuidOne = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}");
                var betGuidOneTwo = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}");
                var betGuidOneThree = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}");

                var betList = new List<Bet>();

                var betOne = new Bet
                {
                    BetId = betGuidOne,
                    MatchBetOn = matchThree,
                    Odds = 110,
                    WinBet = true,
                    BetOn = competitorTwo,
                    BetAgainst = competitorThree,
                    WagerAmount = 100,
                    NetReturn = 110,
                    IsParlayLeg = false,
                    DatePlaced = DateTime.Now,
                    IsComplete = true,
                };

                betList.Add(betOne);

                var betTwo = new Bet
                {
                    BetId = betGuidOneTwo,
                    MatchBetOn = matchOne,
                    Odds = -150,
                    WinBet = true,
                    BetOn = competitorTwo,
                    BetAgainst = competitorOne,
                    IsParlayLeg = true,
                    IsComplete = true,
                };
             
                betList.Add(betTwo);
                var betThree = new Bet
                {
                    BetId = betGuidOneThree,
                    MatchBetOn = matchTwo,
                    Odds = -200,
                    WinBet = true,
                    BetOn = competitorThree,
                    BetAgainst = competitorOne,
                    IsParlayLeg = true,
                    IsComplete = true,
                };
                betList.Add(betThree);

                betStackAppDb.Bets.AddRange(betList);

                betStackAppDb.SaveChanges();

                var paralayBetList = new List<Bet> { betTwo, betThree };
                var parlayOneGuid = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}");

                var parlayOne = new Parlay
                {
                    ParlayId = parlayOneGuid,
                    DateOfCompletion = DateTime.Now,
                    DatePlaced = DateTime.Now,
                    AmountWagered = 100,
                    WinParlay = true,
                    NetReturn = 200,
                    ParlayOdds = 100,
                    ParlayBets = paralayBetList,
                };

                betStackAppDb.Parlays.Add(parlayOne);
                betStackAppDb.SaveChanges();
            }
        }
    }
}
