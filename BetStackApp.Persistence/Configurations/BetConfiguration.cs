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
    public class BetConfiguration: IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            //just did one need to fill out model controls
            //builder.Property(o => o.WagerAmount).IsRequired();
        }
    }
}
