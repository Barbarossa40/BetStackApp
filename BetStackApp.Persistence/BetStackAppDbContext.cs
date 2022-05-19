using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BetStackApp.Domain.Entities;

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
        }

    }
}
