using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webitel.Models;

namespace Webitel
{
    public class ContextDb : DbContext
    {
        private static readonly ContextDb instance = new ContextDb();
            
        public ContextDb() 
        {
            //Database.EnsureCreated();
        }

        public static ContextDb GetInstance()
        {
            return instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebitelDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18, 0)");
            modelBuilder.Entity<Order>().Property(x => x.Amount).HasColumnType("decimal(18, 0)");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
