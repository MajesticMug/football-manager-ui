using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.ResponseModels;
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
        [ProducesResponseType(200, Type = typeof(TotalPlayersResponse))]
        [ProducesResponseType(404, Type = typeof(MessageResponse))]
        public async Task<IActionResult> GetTotalPlayersByLeagueCode([FromRoute] string leagueCode)
        {
            return Ok(await _mediator.Send(new GetTotalPlayersByLeagueCodeQuery
            {
                LeagueCode = leagueCode
            }));
        }

        [HttpGet("{teamCode}")]
        [ProducesResponseType(200, Type = typeof(Player[]))]
        [ProducesResponseType(404, Type = typeof(MessageResponse))]
        public async Task<IActionResult> GetPlayersByTeamCode([FromRoute] string teamCode)
        {
            return Ok(await _mediator.Send(new GetPlayersByTeamCodeQuery {TeamCode = teamCode}));
        }
    }
}
