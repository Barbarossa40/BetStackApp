﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor
{
    public class CreateCompetitorCommand: IRequest<CreateCompetitorCommandResponse>
    {
        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Notes { get; set; }
    }
}
