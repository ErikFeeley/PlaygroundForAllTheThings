using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.v3;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Dtos;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Controllers.Api
{
    [Route("/api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // just gonna directly use the context here for a quick test.
        public ToDosController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoThing>> GetAll()
        {
            var result = await _dbContext
                .ToDoThings
                .ToListAsync();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _dbContext.ToDoThings.Include(tdt => tdt.ApplicationUser).FirstOrDefaultAsync(tdt => tdt.Id == id);

            var toDoDto = new ToDoDto
            {
                Title = result.Title,
                Description = result.Description,
                OwnerEmail = result.ApplicationUser.Email

            };

            return Ok(toDoDto.ToJson());
        }
    }
}
