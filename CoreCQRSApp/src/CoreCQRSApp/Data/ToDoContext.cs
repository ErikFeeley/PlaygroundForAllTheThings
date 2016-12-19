using CoreCQRSApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreCQRSApp.Data
{
    public class ToDoContext : IdentityDbContext<ToDoUser>
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // can add customization for entities here
        }
    }
}
