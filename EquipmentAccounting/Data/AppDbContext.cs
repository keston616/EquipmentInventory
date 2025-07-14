using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentAccounting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EquipmentAccounting.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=equipment.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>(entity =>
            {
                // Явно указываем имена столбцов (хотя они уже совпадают)
                entity.Property(e => e.TypeId).HasColumnName("TypeId");
                entity.Property(e => e.StatusId).HasColumnName("StatusId");

                // Настройка связей
                entity.HasOne(e => e.Type)
                    .WithMany()
                    .HasForeignKey(e => e.TypeId);

                entity.HasOne(e => e.Status)
                    .WithMany()
                    .HasForeignKey(e => e.StatusId);
            });
        }
    }
}
