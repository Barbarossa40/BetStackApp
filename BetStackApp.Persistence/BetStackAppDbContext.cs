using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BetStackApp.Domain.Entities;
using BetStackApp.Domain.Common;


namespace BetStackApp.Persistence
{
    public class BetStackAppDbContext : DbContext
    {

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Parlay> Parlays { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Competitor> Competitors { get; set; }

        public BetStackAppDbContext(DbContextOptions<BetStackAppDbContext> options): base(options)
        {

        }
    
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BetStackAppDbContext).Assembly);

           
            var competitorGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
           

            modelBuilder.Entity<Competitor>().HasData(new Competitor
            {
                CompetitorId = competitorGuid,
                Name = "Geoffrey",
                HomeBase ="Lake Orion, MI USA",
                Description ="According to his mother he is, a very handsome man"
            }) ;
            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 1,
                MatchEventName = "The Rumble From Down Under",
                MatchDate = DateTime.Now,
                Sport = "Mixed Martial Arts",
                League = "LOBO Fight Club"

            }) ;
        }

        // this piece of code updates the tracking properties that each entity inherited from the Auditable base class
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        //entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }

}
