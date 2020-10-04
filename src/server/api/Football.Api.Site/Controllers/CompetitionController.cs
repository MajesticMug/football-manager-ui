using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Site.Controllers
{
    [Route("competitions")]
    [Produces("application/json")]
    public class CompetitionController : Controller
    {
        private readonly IMediator _mediator;

        public CompetitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Competition[]))]
        public async Task<IActionResult> GetAllCompetitions()
        {
            return Ok(await _mediator.Send(new GetAllCompetitionsQuery()));
        }
    }
}
