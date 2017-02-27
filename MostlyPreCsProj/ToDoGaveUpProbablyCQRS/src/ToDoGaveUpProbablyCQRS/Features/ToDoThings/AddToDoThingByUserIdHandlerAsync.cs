using System.Threading.Tasks;
using MediatR;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class AddToDoThingByUserIdHandlerAsync : IAsyncRequestHandler<AddToDoThingByUserIdCommandAsync, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddToDoThingByUserIdHandlerAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddToDoThingByUserIdCommandAsync message)
        {
            var toDo = new ToDoThing
            {
                ApplicationUserId = message.UserId,
                Title = message.ToDoThingViewModel.Title,
                Description = message.ToDoThingViewModel.Description
            };

            var entityEntryResult = await _dbContext.ToDoThings.AddAsync(toDo);
            await _dbContext.SaveChangesAsync();

            return entityEntryResult.Entity.Id;
        }
    }
}
