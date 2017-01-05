using System.Threading.Tasks;
using MediatR;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class AddToDoThingByUserIdHandlerAsync : IAsyncRequestHandler<AddToDoThingByUserIdCommandAsync, ToDoThing>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddToDoThingByUserIdHandlerAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoThing> Handle(AddToDoThingByUserIdCommandAsync message)
        {
            var toDo = new ToDoThing
            {
                ApplicationUserId = message.UserId,
                Title = message.ToDoThingViewModel.Title,
                Description = message.ToDoThingViewModel.Description
            };

            await _dbContext.ToDoThings.AddAsync(toDo);

            await _dbContext.SaveChangesAsync();

            return toDo;
        }
    }
}
