using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoBase.Models;

namespace ToDoBase.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDo> ToDos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // So now that were after the onmodelcreating lets add configuration...


            // ToDoo entity configuration extra o to avoid comment highlighting.
            builder.Entity<ToDo>()
                .Property(p => p.Title)
                .HasMaxLength(25)
                .IsRequired();

            builder.Entity<ToDo>()
                .Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            // ApplicationUser entity configuration.
            builder.Entity<ApplicationUser>()
                .HasMany(appUser => appUser.ToDos)
                .WithOne(todo => todo.ApplicationUser)
                .IsRequired();
        }
    }
}
