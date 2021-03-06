﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoThing> ToDoThings { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // join entity
        public DbSet<ToDoThingTag> ToDoThingTags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // efcore currently lacks support for a EntityTypeConfiguration class so for now just going with private static methods
            ConfigureApplicationUserEntity(builder);
            ConfigureToDoThingEntity(builder);

            builder.Entity<ToDoThingTag>().HasKey(k => new { k.ToDoThingId, k.TagId });

            builder.Entity<ToDoThingTag>().HasOne(tdtt => tdtt.ToDoThing)
                .WithMany(tdt => tdt.ToDoThingTags)
                .HasForeignKey(tdtt => tdtt.ToDoThingId);

            builder.Entity<ToDoThingTag>().HasOne(tdtt => tdtt.Tag)
                .WithMany(t => t.ToDoThingTags)
                .HasForeignKey(tdtt => tdtt.TagId);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private static void ConfigureToDoThingEntity(ModelBuilder builder)
        {
            builder.Entity<ToDoThing>()
                            .Property(toDoThing => toDoThing.Description)
                            .HasMaxLength(500)
                            .IsRequired();

            builder.Entity<ToDoThing>()
                            .Property(tdt => tdt.Title)
                            .HasMaxLength(50)
                            .IsRequired();
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
