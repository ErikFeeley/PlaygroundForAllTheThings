using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Dtos;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdHandlerAsync : IAsyncRequestHandler<ToDoThingByIdQuery, ToDoDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoThingByIdHandlerAsync(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ToDoDto> Handle(ToDoThingByIdQuery message)
        {
            return await _dbContext.ToDoThings
                .Include(tdt => tdt.ApplicationUser)
                .Where(tdt => tdt.Id == message.Id)
                .Select(toDoDto => new ToDoDto(toDoDto.Title, toDoDto.Description, toDoDto.ApplicationUser.Email))
                .FirstOrDefaultAsync();
        }
    }
}
