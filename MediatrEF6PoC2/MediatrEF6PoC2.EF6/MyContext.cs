﻿using System.Data.Entity;

namespace MediatrEF6PoC2.EF6
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<MyValueEntity> MyValueEntities { get; set; }
    }
}
