using EF6PoC.Data.Interfaces;
using StructureMap;

namespace EF6PoC.Data.Implementation.EF6
{
    public class ImplementationEF6Registry : Registry
    {
        public ImplementationEF6Registry()
        {
            For<IValueRepository>().Use<ValueRepository>();
        }
    }
}
