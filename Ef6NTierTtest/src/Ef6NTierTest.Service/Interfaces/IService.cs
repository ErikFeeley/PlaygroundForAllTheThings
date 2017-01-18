using System.Collections.Generic;

namespace Ef6NTierTest.Service.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> Get();
    }
}
