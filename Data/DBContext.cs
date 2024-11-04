using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoApi.Model;

namespace MongoApi.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Supplier> Supplier { get; init; }
        public DbSet<UserModel> User { get; init; }
        public DBContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Supplier>().ToCollection("supplier");
            modelBuilder.Entity<UserModel>().ToCollection("user");
        }
    }
}
