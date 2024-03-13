using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiDashboardCrawler.models
{
    public partial class dbbenchdashboardContext : DbContext
    {
        public dbbenchdashboardContext()
        {
        }

        public dbbenchdashboardContext(DbContextOptions<dbbenchdashboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logbenchdashboard> Logbenchdashboards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=dbbenchmarking.cfk2cqm644xo.us-east-2.rds.amazonaws.com;Initial Catalog=dbbenchdashboard;User Id=admin;Password=master12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logbenchdashboard>(entity =>
            {
                entity.ToTable("Logbenchdashboard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigorobo).HasColumnName("codigorobo");

                entity.Property(e => e.Dataatualizacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataatualizacao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Economia).HasColumnName("economia");

                entity.Property(e => e.Nomedev)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomedev");

                entity.Property(e => e.Nomeproduto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeproduto");

                entity.Property(e => e.Valor1).HasColumnName("valor1");

                entity.Property(e => e.Valor2).HasColumnName("valor2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
