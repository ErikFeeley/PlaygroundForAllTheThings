using StructureMap;

namespace EFTest.Data.EF6Context
{
    public class EF6ContextRegistry : Registry
    {
        public EF6ContextRegistry()
        {
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=EFTestDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}

// holy shit now this works. ok this registry is the one that is really needed.