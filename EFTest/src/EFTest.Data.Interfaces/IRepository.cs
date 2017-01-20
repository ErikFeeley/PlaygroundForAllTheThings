using System.Collections.Generic;

namespace EFTest.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
