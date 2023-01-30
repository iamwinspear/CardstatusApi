using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MessagingAPI.Models
{
    public partial class INRSContext : DbContext
    {
        public INRSContext()
        {
        }

        public INRSContext(DbContextOptions<INRSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonView> PersonViews { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-V5D0ML2\\SQLEXPRESS;Database=INRS;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PersonView");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Pin).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.Telephone).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
