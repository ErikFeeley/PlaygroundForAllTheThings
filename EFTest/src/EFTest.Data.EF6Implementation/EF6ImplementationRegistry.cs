using EFTest.Data.Interfaces;
using StructureMap;

namespace EFTest.Data.EF6Implementation
{
    public class EF6ImplementationRegistry : Registry
    {
        public EF6ImplementationRegistry()
        {
            For<IValueRepository>().Use<ValueRepository>();
        }
    }
}
