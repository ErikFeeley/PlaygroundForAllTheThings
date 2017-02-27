using System;
using System.Threading.Tasks;
using MediatR;
using PlayingWithVS2017RC.Messages.Queries;
using System.Collections.Generic;
using PlayingWithVS2017RC.Data;

namespace PlayingWithVS2017RC.Handlers
{
    public class GetMyStuffHandler : IAsyncRequestHandler<GetMyStuffQuery, IEnumerable<string>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetMyStuffHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> Handle(GetMyStuffQuery message)
        {
            return new List<string>();
        }
    }
}
