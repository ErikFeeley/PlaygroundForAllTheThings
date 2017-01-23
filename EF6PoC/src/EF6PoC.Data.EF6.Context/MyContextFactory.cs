using System.Data.Entity.Infrastructure;

namespace EF6PoC.Data.EF6.Context
{
    public class MyContextFactory : IDbContextFactory<MyContext>
    {
        public MyContext Create()
        {
            // need this for package manager console tooling to work
            return new MyContext("Server=(localdb)\\mssqllocaldb;Database=EFPoCDb;Trusted_Connection=True;MultipleActiveResultSets=true"); // i think this is different cuz i updated netstandard this time.
        }
    }
}
