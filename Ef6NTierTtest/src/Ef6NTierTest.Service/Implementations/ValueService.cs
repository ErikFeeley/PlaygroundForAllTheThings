using System.Collections.Generic;
using Ef6NTierTest.Models;
using Ef6NTierTest.Service.Interfaces;

namespace Ef6NTierTest.Service.Implementations
{
    public class ValueService : IValueService
    {
        public ValueService()
        {
            
        }

        public IEnumerable<Value> Get()
        {
            return new List<Value>
            {
                new Value
                {
                    Id = 1,
                    Blurb = "blurby blurb"
                }
            };
        }
    }
}
