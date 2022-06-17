using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorList;
using BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor;

namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompetitorController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompetitorListVm>>> GetAllCompetitors()
        {
            GetCompetitorListQuery competitorListQuery = new GetCompetitorListQuery() { };

            var competitors = await _mediator.Send(competitorListQuery);

            return Ok(competitors);
        }

        [HttpGet]
        [Route("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompetitorListVm>>> GetCompetitorDetail(Guid competitorId)
        {
            GetCompetitorDetailsQuery competitorDetailQuery = new GetCompetitorDetailsQuery() {CompetitorId =competitorId };

            var competitor = await _mediator.Send(competitorDetailQuery);

            return Ok(competitor);
        }

        [HttpPost]
        [Route("add")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCompetitorCommandResponse>> Create([FromBody] CreateCompetitorCommand createCompetitorCommand)
        {
            var response = await _mediator.Send(createCompetitorCommand);
            return Ok(response);
        }

    }
}
