using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsQueryHandler : IAsyncRequestHandler<ToDoThingsQuery, IEnumerable<ToDoThing>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoThingsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoThing>> Handle(ToDoThingsQuery message)
        {
            return await _dbContext.ToDoThings.ToListAsync();
        }
    }
}
