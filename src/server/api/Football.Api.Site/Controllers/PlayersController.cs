using System.Threading.Tasks;
using Football.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Site.Controllers
{
    [Route("players")]
    [Produces("application/json")]
    public class PlayersController : Controller
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("total-players/{leagueCode}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTotalPlayersByLeagueCode([FromRoute] string leagueCode)
        {
            var totalPlayers = await _mediator.Send(new GetTotalPlayersByLeagueCodeQuery
            {
                LeagueCode = leagueCode
            });

            return Ok(new {Total = totalPlayers});
        }
    }
}
