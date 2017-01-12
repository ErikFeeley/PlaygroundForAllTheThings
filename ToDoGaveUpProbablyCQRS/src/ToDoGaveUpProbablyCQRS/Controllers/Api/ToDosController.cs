using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Dtos;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _dbContext
                .ToDoThings
                .ToListAsync();

            return Ok(result);
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

            return Ok(toDoDto);
        }
    }
}
