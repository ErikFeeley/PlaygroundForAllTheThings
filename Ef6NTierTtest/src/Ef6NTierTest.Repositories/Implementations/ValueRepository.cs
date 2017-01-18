//using System.Collections.Generic;
//using System.Linq;
//using Ef6NTierTest.Data.EF6;
//using Ef6NTierTest.Models;
//using Ef6NTierTest.Repositories.Interfaces;

//namespace Ef6NTierTest.Repositories.Implementations
//{
//    public class ValueRepository :IValueRepository
//    {
//        private readonly MyDbContext _dbContext;

//        public ValueRepository(MyDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Value> Get()
//        {
//            var values = new List<Value>();

//            var valueEntities = _dbContext.Values.ToList();

//            foreach (var valueEntity in valueEntities)
//            {
//                var value = new Value
//                {
//                    Id = valueEntity.Id,
//                    Blurb = valueEntity.Blurb
//                };

//                values.Add(value);
//            }

//            return values;
//        }
//    }
//}
