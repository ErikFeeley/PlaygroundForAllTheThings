using System.Data.Entity.Infrastructure;

namespace MediatrEF6PoC3.EF6
{
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new MyContext("Server=(localdb)\\mssqllocaldb;Database=MediatrEF6PoC3Db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
