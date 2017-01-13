using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Features.ToDoThings;

namespace ToDoGaveUpProbablyCQRS.Controllers.Api
{
    [Route("/api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly IMediator _mediator;
        public ToDosController(ApplicationDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ToDoThingsQuery());

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new ToDoThingByIdQuery(id));

            return Ok(result);
        }
    }
}
