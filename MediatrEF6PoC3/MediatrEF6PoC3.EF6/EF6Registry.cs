using StructureMap;

namespace MediatrEF6PoC3.EF6
{
    public class EF6Registry : Registry
    {
        public EF6Registry()
        {
            For<MyContext>()
                .Use(
                    new MyContext(
                        "Server=(localdb)\\mssqllocaldb;Database=MediatrEF6PoC3Db;Trusted_Connection=True;MultipleActiveResultSets=true"))
                .ContainerScoped();
        }
    }
}
