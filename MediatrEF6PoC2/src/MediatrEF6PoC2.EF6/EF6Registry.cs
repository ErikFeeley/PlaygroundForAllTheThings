using StructureMap;

namespace MediatrEF6PoC2.EF6
{
    public class EF6Registry : Registry
    {
        public EF6Registry()
        {
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=MediatrEF6PoC2Db;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}
