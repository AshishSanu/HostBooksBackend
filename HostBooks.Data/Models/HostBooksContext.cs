using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HostBooks.Data.Models
{
    public partial class HostBooksContext : DbContext
    {
        public HostBooksContext()
        {
        }

        public HostBooksContext(DbContextOptions<HostBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bulkrecord> Bulkrecord { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=HostBooks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bulkrecord>(entity =>
            {
                entity.ToTable("bulkrecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(200);

                entity.Property(e => e.ItemType).HasMaxLength(200);

                entity.Property(e => e.OrderDate).HasMaxLength(50);

                entity.Property(e => e.OrderId).HasMaxLength(20);

                entity.Property(e => e.OrderPriority)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Region).HasMaxLength(500);

                entity.Property(e => e.SalesChannel).HasMaxLength(200);

                entity.Property(e => e.ShipDate).HasMaxLength(50);

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalProfit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
