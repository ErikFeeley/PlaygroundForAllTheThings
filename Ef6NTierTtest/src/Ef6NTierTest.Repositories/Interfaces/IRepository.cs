using System.Collections.Generic;

namespace Ef6NTierTest.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
