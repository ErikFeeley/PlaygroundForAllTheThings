using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.ViewModels;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdHandlerAsync : IAsyncRequestHandler<ToDoThingByIdQuery, ToDoThingViewModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoThingByIdHandlerAsync(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ToDoThingViewModel> Handle(ToDoThingByIdQuery message)
        {
            var result = _dbContext.ToDoThings
                .Where(tdt => tdt.Id == message.Id)
                .Select(tdtvm => new ToDoThingViewModel { Title = tdtvm.Title, Description = tdtvm.Description }).AsQueryable();

            return await result.FirstOrDefaultAsync();
        }
    }
}
