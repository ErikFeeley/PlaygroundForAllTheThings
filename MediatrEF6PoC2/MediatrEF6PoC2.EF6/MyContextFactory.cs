using System.Data.Entity.Infrastructure;

namespace MediatrEF6PoC2.EF6
{
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new MyContext("Server=(localdb)\\mssqllocaldb;Database=MediatrEF6PoC2Db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
