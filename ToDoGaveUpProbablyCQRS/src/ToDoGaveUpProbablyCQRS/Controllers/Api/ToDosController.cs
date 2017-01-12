using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Dtos;
using ToDoGaveUpProbablyCQRS.Features.ToDoThings;

namespace ToDoGaveUpProbablyCQRS.Controllers.Api
{
    [Route("/api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly IMediator _mediator;
        // just gonna directly use the context here for a quick test.... also getting mediatr going...
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new ToDoThingByIdQuery { Id = id });

            var toDoDto = new ToDoDto
            {
                Title = result.Title,
                Description = result.Description,
                OwnerEmail = result.ApplicationUser.Email

            };

            return Ok(toDoDto);
        }
    }
}
