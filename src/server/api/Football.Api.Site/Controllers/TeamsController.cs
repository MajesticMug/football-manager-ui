using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Site.Controllers
{
    [Route("teams")]
    [Produces("application/json")]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Team[]))]
        [ProducesResponseType(404, Type = typeof(MessageResponse))]
        public async Task<IActionResult> GetTeamsByLeagueCode(GetTeamsByLeagueCodeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
