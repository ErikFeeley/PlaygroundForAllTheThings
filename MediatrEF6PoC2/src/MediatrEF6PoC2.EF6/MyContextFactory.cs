using System.Data.Entity.Infrastructure;

namespace MediatrEF6PoC2.EF6
{
    /// <summary>
    /// We need to create this contextfactory class in order for the EF6 tools to work correctly.
    /// </summary>
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new MyContext("Server=(localdb)\\mssqllocaldb;Database=MediatrEF6PoC2Db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
