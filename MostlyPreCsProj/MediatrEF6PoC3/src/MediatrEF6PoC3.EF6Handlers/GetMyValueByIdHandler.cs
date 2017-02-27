using System.Data.Entity;
using System.Threading.Tasks;
using MediatrEF6PoC3.EF6;
using MediatrEF6PoC3.Messages.Query;
using MediatrEF6PoC3.Models;
using MediatR;

namespace MediatrEF6PoC3.EF6Handlers
{
    public class GetMyValueByIdHandler : IAsyncRequestHandler<GetMyValueByIdQuery, MyValue>
    {
        private readonly MyContext _dbContext;

        public GetMyValueByIdHandler(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MyValue> Handle(GetMyValueByIdQuery message)
        {
            var valueEntity =
                await _dbContext.MyValueEntities.FirstOrDefaultAsync(myValueEntity => myValueEntity.Id == message.Id);

            var myValue = new MyValue
            {
                Id = valueEntity.Id,
                Blurb = valueEntity.Blurb
            };

            return myValue;
        }
    }
}
