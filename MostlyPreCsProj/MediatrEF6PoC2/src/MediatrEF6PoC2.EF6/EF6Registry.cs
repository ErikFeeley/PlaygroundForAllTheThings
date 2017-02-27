using StructureMap;

namespace MediatrEF6PoC2.EF6
{
    /// <summary>
    /// structuremap registry which is needed to ensure proper context creation.
    /// refactor note, move hardcoded strign into some kind of options object.
    /// </summary>
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
