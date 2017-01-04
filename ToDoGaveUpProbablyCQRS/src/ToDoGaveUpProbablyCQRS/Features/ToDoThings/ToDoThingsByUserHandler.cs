using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsByUserHandler : IAsyncRequestHandler<ToDoThingsByUserIdQuery, IEnumerable<ToDoThing>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoThingsByUserHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoThing>> Handle(ToDoThingsByUserIdQuery query)
        {
            return await _dbContext.ToDoThings.Where(tdt => tdt.ApplicationUserId == query.UserId).ToListAsync();
        }
    }
}
