using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence.Context
{
    public class CacheNQueueDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        private readonly IConfiguration _configuration;
        public const string DEFAULT_SCHEMA = "dbo";

        public CacheNQueueDbContext()
        {

        }

        public CacheNQueueDbContext(DbContextOptions<CacheNQueueDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=BATUHAN\\SQLEXPRESS;Initial Catalog=CacheNQueue;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connStr);
            }
        }


        public DbSet<Product> Products { get; set; } // Ürünler tablosu
        public DbSet<Order> Orders { get; set; } // Siparişler tablosu
        public DbSet<OrderItem> OrderItems { get; set; } // Sipariş detayları tablosu 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); // We need to add this line because we inherit from IdentityDbContext. If we are not using IdentityDbContext we do not need to add this line.
        }

    }
}
