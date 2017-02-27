using System.Collections.Generic;
using System.Linq;
using EFTestTakeTwo.Data.EF.Context;
using EFTestTakeTwo.Data.Interfaces;
using EFTestTakeTwo.Data.Models;

namespace EFTestTakeTwo.Data.EF.Implementations
{
    public class ValueRepository : IValueRepository
    {
        private readonly MyContext _dbContext;

        public ValueRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MyValue> Get()
        {
            var entityValues = _dbContext.MyValueEntities.ToList();

            return entityValues.Select(entityValue => new MyValue
            {
                Id = entityValue.Id,
                Blurb = entityValue.Blurb
            }).ToList();
        }
    }
}
