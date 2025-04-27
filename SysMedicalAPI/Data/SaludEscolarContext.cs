using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SysMedicalAPI.Models;

namespace SysMedicalAPI.Data;

public partial class SaludEscolarContext : DbContext
{
  public SaludEscolarContext()
  {
  }

  public SaludEscolarContext(DbContextOptions<SaludEscolarContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

  public virtual DbSet<Dispositivo> Dispositivos { get; set; }

  public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

  public virtual DbSet<Lectura> Lecturas { get; set; }

  public virtual DbSet<Medicamento> Medicamentos { get; set; }

  public virtual DbSet<Receta> Recetas { get; set; }

  public virtual DbSet<Sintoma> Sintomas { get; set; }

  public virtual DbSet<Usuario> Usuarios { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Diagnostico>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Diagnost__3214EC07ECEA37F8");

      entity.Property(e => e.FechaDiagnostico).HasDefaultValueSql("(getdate())");

      entity.HasOne(d => d.Sintoma).WithMany(p => p.Diagnosticos)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Diagnosti__Sinto__32E0915F");

      entity.HasOne(d => d.Usuario).WithMany(p => p.Diagnosticos)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Diagnosti__Usuar__31EC6D26");
    });

    modelBuilder.Entity<Dispositivo>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Disposit__3214EC0728FD3C26");

      entity.HasOne(d => d.UsuarioAsignadoNavigation).WithMany(p => p.Dispositivos).HasConstraintName("FK__Dispositi__Usuar__276EDEB3");
    });

    modelBuilder.Entity<HistorialMedico>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07745A3550");

      entity.Property(e => e.FechaEvento).HasDefaultValueSql("(getdate())");

      entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialMedicos)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Historial__Usuar__3E52440B");
    });

    modelBuilder.Entity<Lectura>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Lecturas__3214EC07E8E1B877");

      entity.Property(e => e.FechaLectura).HasDefaultValueSql("(getdate())");

      entity.HasOne(d => d.Dispositivo).WithMany(p => p.Lecturas)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Lecturas__Dispos__2C3393D0");

      entity.HasOne(d => d.Usuario).WithMany(p => p.Lecturas)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Lecturas__Usuari__2B3F6F97");
    });

    modelBuilder.Entity<Medicamento>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Medicame__3214EC0780AD9E00");
    });

    modelBuilder.Entity<Receta>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Recetas__3214EC0789778520");

      entity.Property(e => e.FechaReceta).HasDefaultValueSql("(getdate())");

      entity.HasOne(d => d.Diagnostico).WithMany(p => p.Receta)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Recetas__Diagnos__398D8EEE");

      entity.HasOne(d => d.Medicamento).WithMany(p => p.Receta)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Recetas__Medicam__3A81B327");

      entity.HasOne(d => d.Usuario).WithMany(p => p.Receta)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__Recetas__Usuario__38996AB5");
    });

    modelBuilder.Entity<Sintoma>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Sintomas__3214EC0758D656F3");
    });

    modelBuilder.Entity<Usuario>(entity =>
    {
      entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC076F8410F6");

      entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
      entity.Property(e => e.Genero).IsFixedLength();
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
