using EFTest.Data.EF6Context;
using EFTest.Data.Interfaces;
using StructureMap;

namespace EFTest.Data.EF6Implementation
{
    public class EF6ImplementationRegistry : Registry
    {
        public EF6ImplementationRegistry()
        {
            For<IValueRepository>().Use<ValueRepository>();
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=EFTestDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}
