using System.Data.Entity;

namespace Ef6NTierTest.Data.EF6
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ValueEntity> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValueEntity>()
                .HasKey(valueEntity => valueEntity.Id)
                .Property(valueEntity => valueEntity.Blurb)
                .HasMaxLength(50)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
