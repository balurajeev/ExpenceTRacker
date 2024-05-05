using Microsoft.EntityFrameworkCore;
using System;
using XTRA.Domain.Entity;

namespace XTRA.Infrastructure.DBcontext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

        public DbSet<Statements> Statements { get; set; }

        public string DbPath { get; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            string folder = System.IO.Directory.GetCurrentDirectory();
            var path = @"C:\Sample Apps\XTRA_Statement\XTRA.API\XTRADB\DB";
            DbPath = System.IO.Path.Join(path, "XTRAinitial.db");

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");
    }
}
