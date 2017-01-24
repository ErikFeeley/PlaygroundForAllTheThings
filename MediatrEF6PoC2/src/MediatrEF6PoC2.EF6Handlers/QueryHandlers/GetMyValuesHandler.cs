using System;
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
