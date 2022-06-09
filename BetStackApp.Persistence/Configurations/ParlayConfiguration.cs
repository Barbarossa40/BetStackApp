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
    public class ParlayConfiguration: IEntityTypeConfiguration<Parlay>
    {
        public void Configure(EntityTypeBuilder<Parlay> builder)
        {
            // builder.(b=>b.someVariable).IsRequired etc.
        }
    }
}
