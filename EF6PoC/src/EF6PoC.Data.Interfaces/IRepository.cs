using System.Collections.Generic;

namespace EF6PoC.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
