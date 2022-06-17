using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BetStackApp.Application.Features.Parlays.Commands.CreateParlay;
using BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail;
using BetStackApp.Application.Features.Parlays.Queries.GetParlayList;

namespace BetStackAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParlayController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParlayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ParlayListVm>>> GetParlayList()
        {
            ParlayListQuery parlayListQuery = new ParlayListQuery();

            var parlayDto = await _mediator.Send(parlayListQuery);

            return (parlayDto);
        }


        [HttpGet]
        [Route("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ParlayDetailVm>> GetParlayDetail(Guid parlayId)
        {
           GetParlayDetailQuery parlayDetailQuery = new GetParlayDetailQuery() { ParlayId =parlayId};

            var paralyDto = await _mediator.Send(parlayDetailQuery);

            return Ok(paralyDto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateParlayCommand createParlayCommand) 
        {
            var response = await _mediator.Send(createParlayCommand);

            return Ok(response);
        }
    }
}
