using System.Data.Entity;

namespace EFTestTakeTwo.Data.EF.Context
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<MyValueEntity> MyValueEntities { get; set; }
    }
}
