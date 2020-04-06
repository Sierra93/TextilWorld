using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextilWorld.Models;

namespace TextilWorld.Data {
    /// <summary>
    /// Класс описывает контекст данных БД.
    /// </summary>
    public class ApplicationDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<CategoryDetails> CategoryesDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MultepleContextTable>()
            .HasKey(t => new { t.UserId });

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
                .HasOne(sc => sc.Category)
                .WithMany(s => s.MultepleContextTables);

            modelBuilder.Entity<MultepleContextTable>()
               .HasOne(sc => sc.CategoryesDetails)
               .WithMany(s => s.MultepleContextTables);
        }
    }
}
