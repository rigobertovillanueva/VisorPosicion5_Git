using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VisorPosicion5.Models;

public partial class VisorPosicionContext : DbContext
{
    public VisorPosicionContext()
    {
    }

    public VisorPosicionContext(DbContextOptions<VisorPosicionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<VentaCompraLink> VentaCompraLinks { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
   // => optionsBuilder.UseSqlServer("Server=DESKTOP-NO8HQI4; Database=VisorPosicion; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Operacio__55433A6B1990F29B");

            entity.ToTable("Operacion");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AvailableAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaOperacion).HasColumnType("datetime");
            entity.Property(e => e.TipoCambio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoOperacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VentaCompraLink>(entity =>
        {
            entity.HasKey(e => e.LinkId).HasName("PK__VentaCom__2D122135506DF005");

            entity.ToTable("VentaCompraLink");

            entity.Property(e => e.AmountLinked).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CompraTransaction).WithMany(p => p.VentaCompraLinkCompraTransactions)
                .HasForeignKey(d => d.CompraTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaCompraLink_CompraTransactionId");

            entity.HasOne(d => d.VentaTransaction).WithMany(p => p.VentaCompraLinkVentaTransactions)
                .HasForeignKey(d => d.VentaTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaCompraLink_VentaTransactionId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
