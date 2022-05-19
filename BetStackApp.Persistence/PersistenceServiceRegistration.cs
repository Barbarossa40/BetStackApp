using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BetStackApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BetStackAppDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("BetStackAppConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBetRepository,BetRespository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IParlayRepository, ParlayRepository>();
            services.AddScoped<ICompetitorRepository, CompetitorRespository>();

            return services;
        }
    }
}
