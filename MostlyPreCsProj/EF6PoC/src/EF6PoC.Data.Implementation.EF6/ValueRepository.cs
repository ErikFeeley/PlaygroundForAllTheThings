using System.Collections.Generic;
using System.Linq;
using EF6PoC.Data.EF6.Context;
using EF6PoC.Data.Interfaces;
using EF6PoC.Data.Models;

namespace EF6PoC.Data.Implementation.EF6
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
            });
        }
    }
}
