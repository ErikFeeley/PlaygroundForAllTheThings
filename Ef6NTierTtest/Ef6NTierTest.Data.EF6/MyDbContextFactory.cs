using System.Data.Entity.Infrastructure;

namespace Ef6NTierTest.Data.EF6
{
    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return
                new EF6.MyDbContext(
                    "Server=(localdb)\\mssqllocaldb;Database=NTierEf6TestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
