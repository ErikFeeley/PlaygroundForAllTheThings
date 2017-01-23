using System.Collections.Generic;

namespace EFTestTakeTwo.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
