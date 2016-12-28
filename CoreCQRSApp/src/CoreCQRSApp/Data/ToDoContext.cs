using CoreCQRSApp.Models;
using CoreCQRSApp.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoreCQRSApp.Data
{
    public class ToDoContext : IdentityDbContext<ToDoUser>
    {
        private readonly ConnectionStrings _connectionStrings;

        public ToDoContext(DbContextOptions<ToDoContext> options, IOptions<ConnectionStrings> connectionStrings) 
            : base(options)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // can add customization for entities here
        }
    }
}
