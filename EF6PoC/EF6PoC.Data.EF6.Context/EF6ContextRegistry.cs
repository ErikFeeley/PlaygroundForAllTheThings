using StructureMap;

namespace EF6PoC.Data.EF6.Context
{
    public class EF6ContextRegistry : Registry
    {
        public EF6ContextRegistry()
        {
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=EFPoCDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}
