using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiDemo1.Modelo.Database
{
    public partial class DBAeroClubContext : DbContext
    {
        public DBAeroClubContext()
        {
        }

        public DBAeroClubContext(DbContextOptions<DBAeroClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeronave> Aeronaves { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Instructore> Instructores { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Piloto> Pilotos { get; set; }
        public virtual DbSet<PilotoVuelo> PilotoVuelos { get; set; }
        public virtual DbSet<Vuelo> Vuelos { get; set; }
        public virtual DbSet<DTO.DTOResultSet> Resultado { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User= sa; Password= Ctek2314;Persist Security Info=False;Initial Catalog=DBAeroClub;Data Source=(local)\\A19");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AI");

            modelBuilder.Entity<Aeronave>(entity =>
            {
                entity.HasKey(e => e.IdAeronave)
                    .HasName("PK__Aeronave__2042F68A6E1F90B7");

                entity.ToTable("Aeronave");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__Horario__1539229B99467CC9");

                entity.ToTable("Horario");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.Horario1)
                    .IsUnicode(false)
                    .HasColumnName("Horario");
            });

            modelBuilder.Entity<Instructore>(entity =>
            {
                entity.HasKey(e => e.IdInstructor)
                    .HasName("PK__Instruct__108500443F838BE8");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Personas__2EC8D2AC31F27CE0");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombresCompletos)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.HasKey(e => e.IdPiloto)
                    .HasName("PK__Pilotos__DB35379FE0AE51DA");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            });

            modelBuilder.Entity<PilotoVuelo>(entity =>
            {
                entity.HasKey(e => e.IdPilotoVuelos)
                    .HasName("PK__PilotoVu__2A5292FAE8835F56");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelo)
                    .HasName("PK__Vuelos__21761726404DE81F");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
