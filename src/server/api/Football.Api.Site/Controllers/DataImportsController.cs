using System.Threading.Tasks;
using Football.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Site.Controllers
{
    [Produces("application/json")]
    public class DataImportsController : Controller
    {
        private readonly IMediator _mediator;

        public DataImportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("import-league/{leagueCode}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ImportLeague([FromRoute] string leagueCode)
        {
            await _mediator.Send(new ImportLeagueCommand {LeagueCode = leagueCode});

            return Ok();
        }
    }
}
