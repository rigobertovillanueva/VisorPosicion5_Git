using System;
using System.Collections.Generic;
using EfCoreDbFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbFirstTutorial.Data;

public partial class BancoCentralContext : DbContext
{
    public BancoCentralContext()
    {
    }

    public BancoCentralContext(DbContextOptions<BancoCentralContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OperacionesInformadas> OperacionesInformadas { get; set; }

    public virtual DbSet<OperacionesPosicion> OperacionesPosicions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-10Q01PT\\MSSQLSERVER02;Database=BancoCentral;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OperacionesInformadas>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ClienteNombre).HasMaxLength(100);
            entity.Property(e => e.ClienteRut).HasMaxLength(50);
            entity.Property(e => e.Ejecutivo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.EstadoSolicitud).HasMaxLength(50);
            entity.Property(e => e.FechaReporte).HasColumnType("date");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.Gestion).HasMaxLength(50);
            entity.Property(e => e.Moneda).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("money");
            entity.Property(e => e.OperacionDetalle).HasMaxLength(50);
            entity.Property(e => e.Operaciones).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.TipoCambio).HasColumnType("money");
        });

        modelBuilder.Entity<OperacionesPosicion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OperacionesPosicion");

            entity.Property(e => e.ClienteNombre).HasMaxLength(100);
            entity.Property(e => e.ClienteRut).HasMaxLength(50);
            entity.Property(e => e.Ejecutivo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.EstadoSolicitud).HasMaxLength(50);
            entity.Property(e => e.FechaReporte).HasColumnType("date");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.Gestion).HasMaxLength(50);
            entity.Property(e => e.Moneda).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("money");
            entity.Property(e => e.OperacionDetalle).HasMaxLength(50);
            entity.Property(e => e.Operaciones).HasMaxLength(50);
            entity.Property(e => e.TipoCambio).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
