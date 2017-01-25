using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MediatrEF6PoC3.EF6;
using MediatrEF6PoC3.Messages.Query;
using MediatrEF6PoC3.Models;
using MediatR;

namespace MediatrEF6PoC3.EF6Handlers
{
    public class GetMyValuesHandler : IAsyncRequestHandler<GetMyValuesQuery, IEnumerable<MyValue>>
    {
        private readonly MyContext _dbContext;

        public GetMyValuesHandler(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MyValue>> Handle(GetMyValuesQuery message)
        {
            var myValues = await _dbContext.MyValueEntities.Select(myValueEntity => new MyValue
            {
                Id = myValueEntity.Id,
                Blurb = myValueEntity.Blurb
            }).ToListAsync();

            return myValues;
        }
    }
}
