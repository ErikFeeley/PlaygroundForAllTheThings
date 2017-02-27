using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MediatrEF6PoC2.EF6;
using MediatrEF6PoC2.Messages.Queries;
using MediatrEF6PoC2.Models;
using MediatR;

namespace MediatrEF6PoC2.EF6Handlers.QueryHandlers
{
    /// <summary>
    /// Gets all MyValueEntities and maps them crudely to MyValues.
    /// Note on mediatr: the IAsyncRequestHandler will map to the first specified type for mediatr to work its pairing of messages to handlers magic.
    /// refactor note => instead of select and creating the MyValues on the fly perhaps bringing in automapper would be a good option.
    /// and yes because this is a get all the GetMyValuesQuery is empty.
    /// </summary>
    public class GetMyValuesHandler : IAsyncRequestHandler<GetMyValuesQuery, IEnumerable<MyValue>>
    {
        private readonly MyContext _dbContext;

        public GetMyValuesHandler(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MyValue>> Handle(GetMyValuesQuery message)
        {
            var results = await _dbContext.MyValueEntities.Select(myValueEntity => new MyValue
            {
                Id = myValueEntity.Id,
                Blurb = myValueEntity.Blurb
            }).ToListAsync();

            return results;
        }
    }
}
