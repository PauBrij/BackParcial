using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParcialVeterinaria.Models;

public partial class ParcialVetContext : DbContext
{
    public ParcialVetContext()
    {
    }

    public ParcialVetContext(DbContextOptions<ParcialVetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alimento> Alimentos { get; set; }

    public virtual DbSet<Cliente2> Cliente2s { get; set; }

    public virtual DbSet<Mascota2> Mascota2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EO6BL16\\SQLEXPRESS; Database=ParcialVet; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alimento>(entity =>
        {
            entity.HasKey(e => e.IdAlimento);

            entity.ToTable("Alimento");

            entity.Property(e => e.IdAlimento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Alimento");
            entity.Property(e => e.EtapaDeCrecimiento)
                .HasMaxLength(50)
                .HasColumnName("Etapa de crecimiento");
            entity.Property(e => e.TipoDeAlimento)
                .HasMaxLength(50)
                .HasColumnName("Tipo de Alimento");
            entity.Property(e => e.TipoDeAnimal)
                .HasMaxLength(50)
                .HasColumnName("Tipo de Animal");
        });

        modelBuilder.Entity<Cliente2>(entity =>
        {
            entity.HasKey(e => e.Cedula);

            entity.ToTable("Cliente2");

            entity.Property(e => e.Cedula).ValueGeneratedNever();
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.IdMascota)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Mascota2>(entity =>
        {
            entity.HasKey(e => e.IdMascota);

            entity.ToTable("Mascota2");

            entity.Property(e => e.IdMascota)
                .ValueGeneratedNever()
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.Edad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdAlimento).HasColumnName("ID_Alimento");
            entity.Property(e => e.Peso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Raza)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
