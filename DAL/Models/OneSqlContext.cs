using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class OneSqlContext : DbContext
    {
        public static string ConStr = "";

        public OneSqlContext()
        {
        }

        public OneSqlContext(DbContextOptions<OneSqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TSchool> TSchool { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TSchool>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.ToTable("T_School");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.SchoolName).HasMaxLength(50);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.UseId);

                entity.ToTable("T_User");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.ParentName).HasMaxLength(50);

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
