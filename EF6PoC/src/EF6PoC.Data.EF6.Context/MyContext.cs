using System.Data.Entity;

namespace EF6PoC.Data.EF6.Context
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base (connectionString)
        {
        }

        public DbSet<MyValueEntity> MyValueEntities { get; set; }
    }
}
