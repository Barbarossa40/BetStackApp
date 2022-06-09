using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetStackApp.Persistence.Configurations
{
    public class CompetitorConfiguration: IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            // builder.(b=>b.somevariable).IsRequired etc
        }

    }
}
