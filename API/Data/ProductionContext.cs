using System;
using System.Collections.Generic;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class ProductionContext : DbContext
{
    public ProductionContext()
    {
    }

    public ProductionContext(DbContextOptions<ProductionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoriapersona> Categoriapersonas { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Contactopersona> Contactopersonas { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Dirpersona> Dirpersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Programacion> Programacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tipocontacto> Tipocontactos { get; set; }

    public virtual DbSet<Tipodireccion> Tipodireccions { get; set; }

    public virtual DbSet<Tipopersona> Tipopersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=joshuarex.com1;database=clay_security", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoriapersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoriapersona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdDep, "idDep_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnName("idDep");
            entity.Property(e => e.NombreCiu)
                .HasMaxLength(45)
                .HasColumnName("nombreCiu");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("idDep");
        });

        modelBuilder.Entity<Contactopersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactopersona");

            entity.HasIndex(e => e.Descripcion, "descripcion_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdPersona, "idPersona_idx");

            entity.HasIndex(e => e.IdTipoContacto, "idTipoContacto_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.IdTipoContacto).HasColumnName("idTipoContacto");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("idPersona");

            entity.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdTipoContacto)
                .HasConstraintName("idTipoContacto");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.IdCliente, "idCliente_idx");

            entity.HasIndex(e => e.IdEmpleado, "idEmpleado_idx");

            entity.HasIndex(e => e.IdEstado, "idEstado_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaContrato).HasColumnName("fechaContrato");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("idCliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("idEmpleadoo");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("idEstado");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.IdPais, "idPais_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.NombreDep)
                .HasMaxLength(45)
                .HasColumnName("nombreDep");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("idPais");
        });

        modelBuilder.Entity<Dirpersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dirpersona");

            entity.HasIndex(e => e.IdPersona, "idPersona_idx");

            entity.HasIndex(e => e.IdTdireccion, "idTDireccion_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.IdTdireccion).HasColumnName("idTDireccion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("idPersonaa");

            entity.HasOne(d => d.IdTdireccionNavigation).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.IdTdireccion)
                .HasConstraintName("idTDireccionn");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estado");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pais");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(45)
                .HasColumnName("nombrePais");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdCat, "idCategoria_idx");

            entity.HasIndex(e => e.IdCiudad, "idCiudad_idx");

            entity.HasIndex(e => e.IdTpersona, "idTipoPersona_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateReg).HasColumnName("dateReg");
            entity.Property(e => e.IdCat).HasColumnName("idCat");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.IdTpersona).HasColumnName("idTPersona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCat)
                .HasConstraintName("idCategoria");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("idCiudad");

            entity.HasOne(d => d.IdTpersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTpersona)
                .HasConstraintName("idTipoPersona");
        });

        modelBuilder.Entity<Programacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("programacion");

            entity.HasIndex(e => e.IdContrato, "idContrato_idx");

            entity.HasIndex(e => e.IdEmpleado, "idEmpleado_idx");

            entity.HasIndex(e => e.IdTurno, "idTurno_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdContrato).HasColumnName("idContrato");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdTurno).HasColumnName("idTurno");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("idContrato");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("idEmpleado");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("idTurno");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Tipocontacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipocontacto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Tipodireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodireccion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Tipopersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipopersona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turnos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.HoraTurnoFin)
                .HasColumnType("datetime")
                .HasColumnName("horaTurnoFin");
            entity.Property(e => e.HoraTurnoInicio)
                .HasColumnType("datetime")
                .HasColumnName("horaTurnoInicio");
            entity.Property(e => e.NombreTurno)
                .HasMaxLength(45)
                .HasColumnName("nombreTurno");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);

            entity.HasMany(d => d.IdRolFks).WithMany(p => p.IdUsuarioFks)
                .UsingEntity<Dictionary<string, object>>(
                    "Rolusuario",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("idRol"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("idUsuario"),
                    j =>
                    {
                        j.HasKey("IdUsuarioFk", "IdRolFk")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("rolusuario");
                        j.HasIndex(new[] { "IdRolFk" }, "idRol_idx");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
