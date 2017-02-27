using System.Data.Entity.Infrastructure;

namespace EFTestTakeTwo.Data.EF.Context
{
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            return new MyContext("Server=(localdb)\\mssqllocaldb;Database=EFTestTakeTwoDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
