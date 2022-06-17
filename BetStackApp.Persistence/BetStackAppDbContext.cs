using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BetStackApp.Domain.Entities;
using BetStackApp.Domain.Common;
using BetStackApp.Persistence.Repos;

namespace BetStackApp.Persistence
{
    public class BetStackAppDbContext : DbContext
    {
        private readonly DataSeeder seeder;

        public BetStackAppDbContext(DataSeeder seeder)
        {
            this.seeder = seeder;
        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Competitor> Competitors { get; set; }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Parlay> Parlays { get; set; }

        public BetStackAppDbContext(DbContextOptions<BetStackAppDbContext> options): base(options)
        {

        }
    
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BetStackAppDbContext).Assembly);




        }

         //this piece of code updates the tracking properties that each entity inherited from the Auditable base class
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                seeder.Seed();
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
