using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Roman.webApi.Domains;

#nullable disable

namespace Roman.webApi.Contexts
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipe> Equipes { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //Vinicius Casa
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-RSG62TB1\\SQLEXPRESS; initial catalog=roman_bd; user Id=sa; pwd=Senai@132;");
                //Vinicius-Senai
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-9K54HD5\\SQLEXPRESS;initial catalog=roman_bd; user Id=sa; pwd=senai@132;");
               // optionsBuilder.UseSqlServer("Data Source=NOTE0113G2\\SQLEXPRESS; initial catalog=roman_bd; user Id=sa; pwd=Senai@132;");
                //Vini
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-DHSRSVI\\SQLEXPRESS; initial catalog=roman_bd; user Id=sa; pwd=senai@132;");
               // optionsBuilder.UseSqlServer("Data Source=DESKTOP-DHSRSVI\\SQLEXPRESS; initial catalog=roman_bd; user Id=sa; pwd=senai@132;");
              //  optionsBuilder.UseSqlServer("Data Source=NOTE0113A3\\SQLEXPRESS; initial catalog=roman_bd; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.HasKey(e => e.IdEquipe)
                    .HasName("PK__equipe__981ACF4568B5D4DD");

                entity.ToTable("equipe");

                entity.Property(e => e.IdEquipe).HasColumnName("idEquipe");

                entity.Property(e => e.NomeEquipe)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEquipe");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__professo__4E7C3C6D95A744F4");

                entity.ToTable("professor");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdEquipe).HasColumnName("idEquipe");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeProfessor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeProfessor");

                entity.HasOne(d => d.IdEquipeNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.IdEquipe)
                    .HasConstraintName("FK__professor__idEqu__2E1BDC42");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__professor__idUsu__2D27B809");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__projeto__8FCCED7688D50D9E");

                entity.ToTable("projeto");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.NomeProjeto)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("nomeProjeto");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdProfessor)
                    .HasConstraintName("FK__projeto__idProfe__32E0915F");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__projeto__idTema__33D4B598");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__tema__BCD9EB484A7013D9");

                entity.ToTable("tema");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.NomeTema)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTema");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipousuario)
                    .HasName("PK__tipoUsua__4B78286B7AAF1941");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__tipoUsua__C6B29FC3E1E38CF6")
                    .IsUnique();

                entity.Property(e => e.IdTipousuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipousuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6C724A3C4");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61648955D181")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
