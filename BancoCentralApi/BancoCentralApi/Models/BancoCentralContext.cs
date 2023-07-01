using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BancoCentralApi.Models;

public partial class BancoCentralContext : DbContext
{
    public BancoCentralContext()
    {
    }

    public BancoCentralContext(DbContextOptions<BancoCentralContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OperacionesInformadas2803> OperacionesInformadas2803s { get; set; }

    public virtual DbSet<OperacionesPosicionDelta2803> OperacionesPosicionDelta2803s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-10Q01PT; Database=BancoCentral; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OperacionesInformadas2803>(entity =>
        {
            entity.ToTable("Operaciones Informadas28_03");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClienteNombre).HasMaxLength(100);
            entity.Property(e => e.ClienteRut).HasColumnType("money");
            entity.Property(e => e.Ejecutivo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.EstadoSolicitud).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_Registro");
            entity.Property(e => e.Gestion).HasMaxLength(50);
            entity.Property(e => e.Moneda).HasMaxLength(50);
            entity.Property(e => e.OperacionDetalle).HasMaxLength(50);
            entity.Property(e => e.Operaciones).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<OperacionesPosicionDelta2803>(entity =>
        {
            entity.ToTable("Operaciones PosicionDelta28_03");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClienteNombre).HasMaxLength(100);
            entity.Property(e => e.ClienteRut).HasColumnType("money");
            entity.Property(e => e.Ejecutivo).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.EstadoSolicitud).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_Registro");
            entity.Property(e => e.Gestion).HasMaxLength(50);
            entity.Property(e => e.Moneda).HasMaxLength(50);
            entity.Property(e => e.OperacionDetalle).HasMaxLength(50);
            entity.Property(e => e.Operaciones).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
