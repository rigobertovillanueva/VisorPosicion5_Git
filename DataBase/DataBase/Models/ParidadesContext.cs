using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Models;

public partial class ParidadesContext : DbContext
{
    public ParidadesContext()
    {
    }

    public ParidadesContext(DbContextOptions<ParidadesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paridade> Paridades { get; set; }

 //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=DESKTOP-10Q01PT;  Database=Paridades; Trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paridade>(entity =>
        {
            entity.HasKey(e => e.ParidadesId).HasName("PK__Paridade__3150EBA5E0818A23");

            entity.Property(e => e.MonedaCodigo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.MontoDolar).HasColumnType("money");
            entity.Property(e => e.MontoPesos).HasColumnType("money");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
