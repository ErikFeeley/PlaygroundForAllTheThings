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
