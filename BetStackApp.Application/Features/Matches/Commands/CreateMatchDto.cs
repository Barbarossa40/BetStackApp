﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Matches.Commands
{
    public class CreateMatchDto
    {

        public Guid MatchId { get; set; }
        public string MatchEventName { get; set; }

        public DateTime MatchDate { get; set; }

        public string Sport { get; set; }

        public string League { get; set; }
    }
}
