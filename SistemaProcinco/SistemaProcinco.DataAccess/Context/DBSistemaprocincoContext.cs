﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaProcinco.Entities.Entities;

#nullable disable

namespace SistemaProcinco.DataAccess.Context
{
    public partial class DBSistemaprocincoContext : DbContext
    {
        public DBSistemaprocincoContext()
        {
        }

        public DBSistemaprocincoContext(DbContextOptions<DBSistemaprocincoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbCargos> tbCargos { get; set; }
        public virtual DbSet<tbCategorias> tbCategorias { get; set; }
        public virtual DbSet<tbCiudades> tbCiudades { get; set; }
        public virtual DbSet<tbContenido> tbContenido { get; set; }
        public virtual DbSet<tbContenidoPorCurso> tbContenidoPorCurso { get; set; }
        public virtual DbSet<tbCursos> tbCursos { get; set; }
        public virtual DbSet<tbCursosImpartidos> tbCursosImpartidos { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbEmpresas> tbEmpresas { get; set; }
        public virtual DbSet<tbEstados> tbEstados { get; set; }
        public virtual DbSet<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        public virtual DbSet<tbInformeEmpleados> tbInformeEmpleados { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbPantallasPorRoles> tbPantallasPorRoles { get; set; }
        public virtual DbSet<tbParticipantes> tbParticipantes { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbTitulos> tbTitulos { get; set; }
        public virtual DbSet<tbTitulosPorEmpleado> tbTitulosPorEmpleado { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<tbCargos>(entity =>
            {
                entity.HasKey(e => e.Carg_Id)
                    .HasName("PK_Carg_Id");

                entity.ToTable("tbCargos", "Pro");

                entity.Property(e => e.Carg_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Carg_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Carg_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Carg_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Carg_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCargosCarg_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Carg_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Carg_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCargosCarg_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Carg_UsuarioModificacion);
            });

            modelBuilder.Entity<tbCategorias>(entity =>
            {
                entity.HasKey(e => e.Cate_Id)
                    .HasName("PK__tbCatego__297787C69519634F");

                entity.ToTable("tbCategorias", "Pro");

                entity.Property(e => e.Cate_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cate_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cate_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Cate_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Cate_Imagen).IsUnicode(false);

                entity.HasOne(d => d.Cate_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCategoriasCate_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Cate_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Cate_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCategoriasCate_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Cate_UsuarioModificacion);
            });

            modelBuilder.Entity<tbCiudades>(entity =>
            {
                entity.HasKey(e => e.Ciud_Id)
                    .HasName("PK__tbCiudad__D04530886F859972");

                entity.ToTable("tbCiudades", "Grl");

                entity.HasIndex(e => e.Ciud_Descripcion, "UK_tbCiudades_Ciud_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Ciud_Id)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Ciud_Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ciud_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Ciud_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Esta_Id)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ciud_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCiudadesCiud_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Ciud_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCiudades_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Ciud_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCiudadesCiud_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Ciud_UsuarioModificacion)
                    .HasConstraintName("FK_tbCiudades_tbUsuarios_UsuarioModificacion");

                entity.HasOne(d => d.Esta)
                    .WithMany(p => p.tbCiudades)
                    .HasForeignKey(d => d.Esta_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCiudades_tbEstartamentos_Esta_Id");
            });

            modelBuilder.Entity<tbContenido>(entity =>
            {
                entity.HasKey(e => e.Cont_Id)
                    .HasName("PK__tbConten__F757F146460D9386");

                entity.ToTable("tbContenido", "Pro");

                entity.Property(e => e.Cont_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cont_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cont_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Cont_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.tbContenido)
                    .HasForeignKey(d => d.Cate_Id);

                entity.HasOne(d => d.Cont_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbContenidoCont_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Cont_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Cont_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbContenidoCont_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Cont_UsuarioModificacion);
            });

            modelBuilder.Entity<tbContenidoPorCurso>(entity =>
            {
                entity.HasKey(e => e.ConPc_Id)
                    .HasName("PK__tbConten__42031BCE0A8B29F8");

                entity.ToTable("tbContenidoPorCurso", "Pro");

                entity.Property(e => e.ConPc_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.ConPc_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.ConPc_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.ConPc_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbContenidoPorCursoConPc_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.ConPc_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ConPc_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbContenidoPorCursoConPc_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.ConPc_UsuarioModificacion);

                entity.HasOne(d => d.Cont)
                    .WithMany(p => p.tbContenidoPorCurso)
                    .HasForeignKey(d => d.Cont_Id);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.tbContenidoPorCurso)
                    .HasForeignKey(d => d.Curso_Id)
                    .HasConstraintName("FK_tbContenidoPorCurso_tbCurso_Curso_Id");
            });

            modelBuilder.Entity<tbCursos>(entity =>
            {
                entity.HasKey(e => e.Curso_Id)
                    .HasName("PK__tbCursos__98A16D2767D50B42");

                entity.ToTable("tbCursos", "Pro");

                entity.Property(e => e.Curso_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Curso_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Curso_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Curso_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Curso_Imagen).IsUnicode(false);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.tbCursos)
                    .HasForeignKey(d => d.Cate_Id);

                entity.HasOne(d => d.Curso_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCursosCurso_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Curso_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Curso_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCursosCurso_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Curso_UsuarioModificacion);

                entity.HasOne(d => d.Empre)
                    .WithMany(p => p.tbCursos)
                    .HasForeignKey(d => d.Empre_Id);
            });

            modelBuilder.Entity<tbCursosImpartidos>(entity =>
            {
                entity.HasKey(e => e.CurIm_Id)
                    .HasName("PK__tbCursos__72B63779DC52F335");

                entity.ToTable("tbCursosImpartidos", "Pro");

                entity.Property(e => e.CurIm_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.CurIm_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.CurIm_FechaFin).HasColumnType("datetime");

                entity.Property(e => e.CurIm_FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.CurIm_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.CurIm_Finalizar).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CurIm_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCursosImpartidosCurIm_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.CurIm_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CurIm_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCursosImpartidosCurIm_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.CurIm_UsuarioModificacion);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.tbCursosImpartidos)
                    .HasForeignKey(d => d.Curso_Id);

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.tbCursosImpartidos)
                    .HasForeignKey(d => d.Empl_Id);
            });

            modelBuilder.Entity<tbEmpleados>(entity =>
            {
                entity.HasKey(e => e.Empl_Id)
                    .HasName("PK__tbEmplea__2EB12E86311F05A9");

                entity.ToTable("tbEmpleados", "Grl");

                entity.Property(e => e.Ciud_id)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_Apellido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_DNI)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Empl_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Empl_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Empl_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Empl_Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Empl_SalarioHora).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Empl_Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Carg)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.Carg_Id);

                entity.HasOne(d => d.Ciud)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.Ciud_id)
                    .HasConstraintName("FK_tbEmpleados_tbCiudades_Ciud_Id");

                entity.HasOne(d => d.Empl_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbEmpleadosEmpl_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Empl_UsuarioCreacion)
                    .HasConstraintName("FK_tbEmpleados_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Empl_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbEmpleadosEmpl_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Empl_UsuarioModificacion)
                    .HasConstraintName("FK_tbEmpleados_tbUsuarios_UsuarioModificacion");

                entity.HasOne(d => d.Estc)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.Estc_Id);
            });

            modelBuilder.Entity<tbEmpresas>(entity =>
            {
                entity.HasKey(e => e.Empre_Id)
                    .HasName("PK__tbEmpres__482561D618E54853");

                entity.ToTable("tbEmpresas", "Grl");

                entity.Property(e => e.Ciud_Id)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Empre_Descripcion)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Empre_Direccion).IsUnicode(false);

                entity.Property(e => e.Empre_Estado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Empre_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Empre_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Ciud)
                    .WithMany(p => p.tbEmpresas)
                    .HasForeignKey(d => d.Ciud_Id);

                entity.HasOne(d => d.Empre_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbEmpresasEmpre_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Empre_UsuarioCreacion);

                entity.HasOne(d => d.Empre_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbEmpresasEmpre_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Empre_UsuarioModificacion);
            });

            modelBuilder.Entity<tbEstados>(entity =>
            {
                entity.HasKey(e => e.Esta_Id)
                    .HasName("PK__tbEstado__D52AE7B89B22AA59");

                entity.ToTable("tbEstados", "Grl");

                entity.HasIndex(e => e.Esta_Descripcion, "UK_tbEstados_Esta_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Esta_Id)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Esta_Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Esta_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Esta_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Esta_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbEstadosEsta_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Esta_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstados_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Esta_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbEstadosEsta_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Esta_UsuarioModificacion)
                    .HasConstraintName("FK_tbEstados_tbUsuarios_UsuarioModificacion");
            });

            modelBuilder.Entity<tbEstadosCiviles>(entity =>
            {
                entity.HasKey(e => e.Estc_Id)
                    .HasName("PK__tbEstado__C225B0E68740B0D2");

                entity.ToTable("tbEstadosCiviles", "Grl");

                entity.HasIndex(e => e.Estc_Descripcion, "UK_tbEstadosCiviles_Estc_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Estc_Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estc_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Estc_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Estc_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Estc_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesEstc_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Estc_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstadosCiviles_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Estc_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesEstc_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Estc_UsuarioModificacion)
                    .HasConstraintName("FK_tbEstadosCiviles_tbUsuarios_UsuarioModificacion");
            });

            modelBuilder.Entity<tbInformeEmpleados>(entity =>
            {
                entity.HasKey(e => e.InfoE_Id)
                    .HasName("PK__tbInform__5F9A22B556011F5B");

                entity.ToTable("tbInformeEmpleados", "Pro");

                entity.Property(e => e.InfoE_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.InfoE_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.InfoE_Observaciones).IsUnicode(false);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.tbInformeEmpleados)
                    .HasForeignKey(d => d.Curso_Id);

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.tbInformeEmpleados)
                    .HasForeignKey(d => d.Empl_Id)
                    .HasConstraintName("FK_tbInformeEmpleados_tbEmpleados_Emp_Id");
            });

            modelBuilder.Entity<tbPantallas>(entity =>
            {
                entity.HasKey(e => e.Pant_Id)
                    .HasName("PK__tbPantal__CF98C932774D19A8");

                entity.ToTable("tbPantallas", "Acc");

                entity.HasIndex(e => e.Pant_Descripcion, "UK_tbPantallas_Pant_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Pant_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Pant_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Pant_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Pant_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Pant_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbPantallasPant_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Pant_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPantallas_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Pant_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbPantallasPant_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Pant_UsuarioModificacion)
                    .HasConstraintName("FK_tbPantallas_tbUsuarios_UsuarioModificacion");
            });

            modelBuilder.Entity<tbPantallasPorRoles>(entity =>
            {
                entity.HasKey(e => e.PaPr_Id)
                    .HasName("PK__tbPantal__43E5C3E819D84DA0");

                entity.ToTable("tbPantallasPorRoles", "Acc");

                entity.Property(e => e.PaPr_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.PaPr_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PaPr_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.PaPr_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolesPaPr_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.PaPr_UsuarioCreacion)
                    .HasConstraintName("FK_tbPantallasPorRoles_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.PaPr_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolesPaPr_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.PaPr_UsuarioModificacion)
                    .HasConstraintName("FK_tbPantallasPorRoles_tbUsuarios_UsuarioModificacion");

                entity.HasOne(d => d.Pant)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.Pant_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPantallasxRol_tbPantallas_Pant_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPantallasxRol_tbRoles_Role_Id");
            });

            modelBuilder.Entity<tbParticipantes>(entity =>
            {
                entity.HasKey(e => e.Part_Id)
                    .HasName("PK__tbPartic__14CFF41017D35259");

                entity.ToTable("tbParticipantes", "Grl");

                entity.Property(e => e.Ciud_id)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Part_Apellido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Part_Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Part_DNI)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Part_Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Part_Estado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Part_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Part_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Part_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Part_Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Part_Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Ciud)
                    .WithMany(p => p.tbParticipantes)
                    .HasForeignKey(d => d.Ciud_id)
                    .HasConstraintName("FK_tbParticipantes_tbCiudades_Ciud_Id");

                entity.HasOne(d => d.Empre)
                    .WithMany(p => p.tbParticipantes)
                    .HasForeignKey(d => d.Empre_Id);

                entity.HasOne(d => d.Estc)
                    .WithMany(p => p.tbParticipantes)
                    .HasForeignKey(d => d.Estc_Id);

                entity.HasOne(d => d.Part_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbParticipantesPart_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Part_UsuarioCreacion);

                entity.HasOne(d => d.Part_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbParticipantesPart_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Part_UsuarioModificacion);
            });

            modelBuilder.Entity<tbRoles>(entity =>
            {
                entity.HasKey(e => e.Role_Id)
                    .HasName("PK__tbRoles__D80AB4BB88BBECB0");

                entity.ToTable("tbRoles", "Acc");

                entity.HasIndex(e => e.Role_Descripcion, "UK_tbRoles_Role_Descripcion")
                    .IsUnique();

                entity.Property(e => e.Role_Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Role_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Role_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Role_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbRolesRole_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Role_UsuarioCreacion)
                    .HasConstraintName("FK_tbRoles_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Role_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbRolesRole_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Role_UsuarioModificacion)
                    .HasConstraintName("FK_tbRoles_tbUsuarios_UsuarioModificacion");
            });

            modelBuilder.Entity<tbTitulos>(entity =>
            {
                entity.HasKey(e => e.Titl_Id)
                    .HasName("PK__tbTitulo__78C8475E35C720F2");

                entity.ToTable("tbTitulos", "Pro");

                entity.Property(e => e.Titl_Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Titl_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Titl_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Titl_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Titl_ValorMonetario).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.Titl_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbTitulosTitl_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Titl_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Titl_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbTitulosTitl_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Titl_UsuarioModificacion);
            });

            modelBuilder.Entity<tbTitulosPorEmpleado>(entity =>
            {
                entity.HasKey(e => e.TitPe_Id)
                    .HasName("PK__tbTitulo__990F716E1C75C18E");

                entity.ToTable("tbTitulosPorEmpleado", "Pro");

                entity.Property(e => e.TitPe_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.TitPe_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TitPe_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.tbTitulosPorEmpleado)
                    .HasForeignKey(d => d.Empl_Id);

                entity.HasOne(d => d.TitPe_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbTitulosPorEmpleadoTitPe_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.TitPe_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TitPe_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbTitulosPorEmpleadoTitPe_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.TitPe_UsuarioModificacion);

                entity.HasOne(d => d.Titl)
                    .WithMany(p => p.tbTitulosPorEmpleado)
                    .HasForeignKey(d => d.Titl_Id);
            });

            modelBuilder.Entity<tbUsuarios>(entity =>
            {
                entity.HasKey(e => e.Usua_Id)
                    .HasName("PK__tbUsuari__E863C8EEACC9F0DC");

                entity.ToTable("tbUsuarios", "Acc");

                entity.HasIndex(e => e.Usua_Usuario, "UK_tbUsuarios_Usua_Usuario")
                    .IsUnique();

                entity.Property(e => e.Usua_Contraseña)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Usua_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Usua_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Usua_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Usua_Usuario)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Usua_VerificarCorreo).IsUnicode(false);

                entity.HasOne(d => d.Empl)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.Empl_Id);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usua_UsuarioCreacionNavigation)
                    .WithMany(p => p.InverseUsua_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Usua_UsuarioCreacion)
                    .HasConstraintName("FK_tbUsuarios_tbUsuarios_UsuarioCreacion");

                entity.HasOne(d => d.Usua_UsuarioModificacionNavigation)
                    .WithMany(p => p.InverseUsua_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Usua_UsuarioModificacion)
                    .HasConstraintName("FK_tbUsuarios_tbUsuarios_UsuarioModificacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}