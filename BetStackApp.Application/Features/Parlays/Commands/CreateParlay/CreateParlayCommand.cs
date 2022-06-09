using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using MediatR;

namespace BetStackApp.Application.Features.Parlays.Commands.CreateParlay
{
    public class CreateParlayCommand: IRequest<Guid>
    {
        public Guid ParlayId { get; set; }

        public DateTime DateOfCompletion { get; set; }

        public DateTime DatePlaced { get; set; }
        public double AmountWagered { get; set; }

        public bool WinParlay { get; set; }

        public double NetReturn { get; set; }

        public double ParlayOdds { get; set; }

        public ICollection<Guid> ParlayIds { get; set; }
    }
}
