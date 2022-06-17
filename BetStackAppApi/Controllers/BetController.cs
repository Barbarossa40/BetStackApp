using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BetStackApp.Application.Features.Bets.Commands.CreateBet;
using BetStackApp.Application.Features.Bets.Commands.DeleteBet;
using BetStackApp.Application.Features.Bets.Commands.UpdateBet;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetail;
using BetStackApp.Application.Features.Bets.Queries.GetBetList;


namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BetListVm>>> GetAllBets(bool includeParlayLegs)
        {
            GetBetListQuery betsListQuery = new GetBetListQuery() { IncludeParlayLegs = includeParlayLegs };

            var betDtos = await _mediator.Send(betsListQuery);

            return Ok(betDtos);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<BetDetailVm>> GetBetDetail(Guid betId)
        {
            GetBetDetailQuery betDetailQuery = new GetBetDetailQuery() { BetId = betId};

            var betDto = await _mediator.Send(betDetailQuery);

            return Ok(betDto);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBet([FromBody] CreateBetCommand createBetCommand)
        {
            var response =await _mediator.Send(createBetCommand);
            return Ok(response);
        }

        //[HttpDelete("{id}", Name = "DeleteEvent")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        
    }
}
