using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trial.Models
{
    public partial class TrialContext : DbContext
    {
        public TrialContext()
        {
        }

        public TrialContext(DbContextOptions<TrialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admint> Admints { get; set; } = null!;
        public virtual DbSet<User1> User1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured){

            }
           
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admint");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password).HasColumnType("text");
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User1");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.FirstName).HasColumnType("text");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
