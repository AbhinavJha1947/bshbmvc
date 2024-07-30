using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BiharStateHousingBoard.Models
{
    public partial class BSHBContext : DbContext
    {
        public BSHBContext()
        {
        }

        public BSHBContext(DbContextOptions<BSHBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenusMvc> MenusMvcs { get; set; } = null!;
        public DbSet<MenusMvc> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VINIT\\SQLEXPRESS;Database=BSHB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenusMvc>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__Menus_MV__C99ED2300325A651");

                entity.ToTable("Menus_MVC");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
