using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi_.Domains;

#nullable disable

namespace senai.hroads.webApi_.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<HabilidadeClasse> HabilidadeClasses { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-RSG62TB1\\SQLEXPRESS; initial catalog=SENAI_HROADS_TARDE; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classes__60FFF801B654D161");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.TipoClasse)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F75281911F4EA");

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Habilidad__idTip__3D5E1FD2");
            });

            modelBuilder.Entity<HabilidadeClasse>(entity =>
            {
                entity.HasKey(e => e.IdHabClasse)
                    .HasName("PK__Habilida__B4DA2B0FDACADD53");

                entity.ToTable("HabilidadeClasse");

                entity.Property(e => e.IdHabClasse).HasColumnName("idHabClasse");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.HabilidadeClasses)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Habilidad__idCla__412EB0B6");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeClasses)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__idHab__403A8C7D");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E09E4B0AD");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.MaxMana)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaxVida)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__3A81B327");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoHabi__BDD0DFE155E4A61B");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.TipoHabilidade1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TipoHabilidade");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF40991196");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoPermissao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipoPermissao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A670EFF3C0");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164DB623659")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
