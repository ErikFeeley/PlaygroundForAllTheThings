using System.Collections.Generic;
using EFTest.Data.Interfaces;
using EFTest.Data.Models;

namespace EFTest.Data.EF6Implementation
{
    public class ValueRepository : IValueRepository
    {
        public IEnumerable<MyValue> Get()
        {
            return new List<MyValue>
            {
                new MyValue
                {
                    Id = 1,
                    Blurb = "blurbity blurb"
                }
            };
        }
    }
}
