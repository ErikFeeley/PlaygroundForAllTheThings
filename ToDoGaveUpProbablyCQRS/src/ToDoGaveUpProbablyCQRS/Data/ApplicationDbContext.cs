using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoThing> ToDoThings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureApplicationUserEntity(builder);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private static void ConfigureApplicationUserEntity(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                            .HasMany(appUser => appUser.ToDoThings)
                            .WithOne(tdt => tdt.ApplicationUser)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
