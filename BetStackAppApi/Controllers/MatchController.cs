using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BetStackApp.Application.Features.Matches.Commands;
using BetStackApp.Application.Features.Matches.Queries.GetMatchDetail;

namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> GetMatchDetail(Guid matchId)
        {
          GetMatchDetailQuery getMatchDetailQuery = new GetMatchDetailQuery() { MatchId = matchId };
            
            var match = await _mediator.Send(getMatchDetailQuery);
            
            return Ok(match);   

        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateMatchCommandResponse>>Create([FromBody] CreateMatchCommand createMatchCommand)
        {
            var response = await _mediator.Send(createMatchCommand);
            return Ok(response);
        }
    }
}
