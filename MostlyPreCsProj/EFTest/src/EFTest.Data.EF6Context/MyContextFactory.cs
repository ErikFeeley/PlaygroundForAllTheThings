using System.Data.Entity.Infrastructure;

namespace EFTest.Data.EF6Context
{
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new EF6Context.MyContext("Server=(localdb)\\mssqllocaldb;Database=EFTestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
