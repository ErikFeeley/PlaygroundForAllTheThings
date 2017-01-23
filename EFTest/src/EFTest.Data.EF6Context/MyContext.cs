using System.Data.Entity;

namespace EFTest.Data.EF6Context
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<MyValueEntity> MyValueEntities { get; set; }
    }
}
