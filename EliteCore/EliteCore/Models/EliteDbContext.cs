using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EliteCore.Models
{
    public class EliteDbContext:DbContext
    {
        public EliteDbContext(DbContextOptions<EliteDbContext> options) : base(options) { }

        // Veritabanı tablolarını temsil eden DbSet'ler
        public DbSet<GelenMail> GelenMailler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Özel model konfigürasyonları buraya eklenebilir
            modelBuilder.Entity<GelenMail>().HasIndex(u => u.GelenMailKod).IsUnique();
        }
    }
}
