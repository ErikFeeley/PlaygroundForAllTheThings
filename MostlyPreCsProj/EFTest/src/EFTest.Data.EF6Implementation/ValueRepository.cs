using System.Collections.Generic;
using System.Linq;
using EFTest.Data.EF6Context;
using EFTest.Data.Interfaces;
using EFTest.Data.Models;

namespace EFTest.Data.EF6Implementation
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
            var myValueEntities = _dbContext.MyValueEntities.ToList();

            return myValueEntities.Select(myValueEntity => new MyValue
            {
                Id = myValueEntity.Id, Blurb = myValueEntity.Blurb
            }).ToList();
        }
    }
}
