using StructureMap;

namespace EFTestTakeTwo.Data.EF.Context
{
    public class EFContextRegistry : Registry
    {
        public EFContextRegistry()
        {
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=EFTestTakeTwoDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }        
    }
}
