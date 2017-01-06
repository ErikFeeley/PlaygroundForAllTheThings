using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsByUserHandlerAsync : IAsyncRequestHandler<ToDoThingsByUserIdQueryAsync, IEnumerable<ToDoThing>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoThingsByUserHandlerAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// returns empty todothing list if db returns nothings.
        /// </summary>
        /// <param name="queryAsync"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ToDoThing>> Handle(ToDoThingsByUserIdQueryAsync queryAsync)
        {
            return await _dbContext.ToDoThings.Where(tdt => tdt.ApplicationUserId == queryAsync.UserId).ToListAsync() ??
                   new List<ToDoThing>();
        }
    }
}
