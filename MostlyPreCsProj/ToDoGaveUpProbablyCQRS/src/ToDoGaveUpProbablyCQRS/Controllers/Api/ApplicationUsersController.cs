using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoGaveUpProbablyCQRS.Features.ApplicationUsers;

namespace ToDoGaveUpProbablyCQRS.Controllers.Api
{
    [Route("/api/[controller]")]
    public class ApplicationUsersController : Controller
    {
        private readonly IMediator _mediator;

        public ApplicationUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _mediator.Send(new GetUsersToDoThingsAndTagsQuery(id));

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
