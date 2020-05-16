using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Escuela.Model
{
    public partial class EscuelaFULLContext : DbContext
    {
        public EscuelaFULLContext()
        {
        }

        public EscuelaFULLContext(DbContextOptions<EscuelaFULLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Coordinador> Coordinador { get; set; }
        public virtual DbSet<EstadoPermiso> EstadoPermiso { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Plantel> Plantel { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermiso { get; set; }
        public virtual DbSet<TipoTrabajador> TipoTrabajador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ceti.database.windows.net,1433;Initial Catalog=EscuelaFULL;Persist Security Info=False;User ID=Equipo2;Password=Lospatrones2000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PK__Contrato__B16B9C1942C2299B");

                entity.Property(e => e.IdContrato).HasColumnName("ID_Contrato");

                entity.Property(e => e.IdTipoContrato).HasColumnName("ID_TipoContrato");

                entity.Property(e => e.IdTipoTrabajador).HasColumnName("ID_TipoTrabajador");

                entity.Property(e => e.SueldoContrato)
                    .HasColumnName("Sueldo_Contrato")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdTipoContratoNavigation)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdTipoContrato)
                    .HasConstraintName("FK__Contrato__ID_Tip__68487DD7");
            });

            modelBuilder.Entity<Coordinador>(entity =>
            {
                entity.HasKey(e => e.NominaCoordinador)
                    .HasName("PK__Coordina__55F37940DF781704");

                entity.Property(e => e.NominaCoordinador).HasColumnName("Nomina_Coordinador");

                entity.Property(e => e.ApelidoMaternoCoordinador)
                    .HasColumnName("ApelidoMaterno_Coordinador")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaternoCoordinador)
                    .HasColumnName("ApellidoPaterno_Coordinador")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContraseñaCoordinador)
                    .HasColumnName("Contraseña_Coordinador")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoCoordinador)
                    .HasColumnName("Correo_Coordinador")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CurpCoordinador)
                    .HasColumnName("CURP_Coordinador")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimientoCoordinador)
                    .HasColumnName("FechaNacimiento_Coordinador")
                    .HasColumnType("date");

                entity.Property(e => e.HorasAsignadasCoordinador).HasColumnName("HorasAsignadas_Coordinador");

                entity.Property(e => e.IdContrato).HasColumnName("ID_Contrato");

                entity.Property(e => e.IdPlantel).HasColumnName("ID_Plantel");

                entity.Property(e => e.NombreCoordinador)
                    .HasColumnName("Nombre_Coordinador")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.Coordinador)
                    .HasForeignKey(d => d.IdContrato)
                    .HasConstraintName("FK__Coordinad__ID_Co__5812160E");
            });

            modelBuilder.Entity<EstadoPermiso>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPermiso)
                    .HasName("PK__Estado_P__D016C07ECE86B2DB");

                entity.ToTable("Estado_Permiso");

                entity.Property(e => e.IdEstadoPermiso).HasColumnName("ID_EstadoPermiso");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permiso__D5B666CC4B4A3788");

                entity.Property(e => e.IdPermiso).HasColumnName("ID_Permiso");

                entity.Property(e => e.FechaInicioPermiso)
                    .HasColumnName("FechaInicio_Permiso")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSolicitudPermiso)
                    .HasColumnName("FechaSolicitud_Permiso")
                    .HasColumnType("date");

                entity.Property(e => e.FechaTerminoPermiso)
                    .HasColumnName("FechaTermino_Permiso")
                    .HasColumnType("date");

                entity.Property(e => e.HoraInicioPermiso).HasColumnName("HoraInicio_Permiso");

                entity.Property(e => e.HoraTeminoPermiso).HasColumnName("HoraTemino_Permiso");

                entity.Property(e => e.MotivoPermiso)
                    .HasColumnName("motivo_Permiso")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Permiso__Estado__37A5467C");

                entity.HasOne(d => d.NominaNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.Nomina)
                    .HasConstraintName("FK__Permiso__Nomina__38996AB5");

                entity.HasOne(d => d.TipoPermisoNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.TipoPermiso)
                    .HasConstraintName("FK__Permiso__TipoPer__6D0D32F4");
            });

            modelBuilder.Entity<Plantel>(entity =>
            {
                entity.HasKey(e => e.IdPlantel)
                    .HasName("PK__Plantel__88326C6971D135E3");

                entity.Property(e => e.IdPlantel).HasColumnName("ID_Plantel");

                entity.Property(e => e.DireccionPlantel)
                    .HasColumnName("Direccion_Plantel")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePlantel)
                    .HasColumnName("Nombre_Plantel")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.NominaProfesor)
                    .HasName("PK__Profesor__27324956CB45C4FE");

                entity.Property(e => e.NominaProfesor).HasColumnName("Nomina_Profesor");

                entity.Property(e => e.ApelidoMaternoProfesor)
                    .HasColumnName("ApelidoMaterno_Profesor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaternoProfesor)
                    .HasColumnName("ApellidoPaterno_Profesor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContraseñaProfesor)
                    .HasColumnName("Contraseña_Profesor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoProfesor)
                    .HasColumnName("Correo_Profesor")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CurpProfesor)
                    .HasColumnName("CURP_Profesor")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimientoProfesor)
                    .HasColumnName("FechaNacimiento_Profesor")
                    .HasColumnType("date");

                entity.Property(e => e.HorasAsignadasProfesor).HasColumnName("HorasAsignadas_Profesor");

                entity.Property(e => e.IdContrato).HasColumnName("ID_Contrato");

                entity.Property(e => e.IdPlantel).HasColumnName("ID_Plantel");

                entity.Property(e => e.NombreProfesor)
                    .HasColumnName("Nombre_Profesor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.Profesor)
                    .HasForeignKey(d => d.IdContrato)
                    .HasConstraintName("FK__Profesor__ID_Con__3A81B327");

                entity.HasOne(d => d.IdPlantelNavigation)
                    .WithMany(p => p.Profesor)
                    .HasForeignKey(d => d.IdPlantel)
                    .HasConstraintName("FK__Profesor__ID_Pla__3B75D760");
            });

            modelBuilder.Entity<TipoContrato>(entity =>
            {
                entity.HasKey(e => e.IdTipoContrato)
                    .HasName("PK__TipoCont__08B0C48D2444AFB1");

                entity.Property(e => e.IdTipoContrato).HasColumnName("ID_TipoContrato");

                entity.Property(e => e.NombreTipoContrato)
                    .HasColumnName("Nombre_TipoContrato")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.HasKey(e => e.IdTipoPermiso)
                    .HasName("PK__Tipo_Per__CDA9D40AC92465ED");

                entity.ToTable("Tipo_Permiso");

                entity.Property(e => e.IdTipoPermiso).HasColumnName("ID_TipoPermiso");

                entity.Property(e => e.NombreTipooPermiso)
                    .HasColumnName("Nombre_TipooPermiso")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTrabajador>(entity =>
            {
                entity.HasKey(e => e.IdTipoTrabajador)
                    .HasName("PK__TipoTrab__11C27DFE1ECEB189");

                entity.Property(e => e.IdTipoTrabajador).HasColumnName("ID_TipoTrabajador");

                entity.Property(e => e.NombreTipoTrabajador)
                    .HasColumnName("Nombre_TipoTrabajador")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
