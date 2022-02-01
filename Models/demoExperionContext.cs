using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class demoExperionContext : DbContext
    {
        public demoExperionContext()
        {
        }

        public demoExperionContext(DbContextOptions<demoExperionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ABHINAVJAIJU\\SQLEXPRESS; Initial Catalog= demoExperion; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
