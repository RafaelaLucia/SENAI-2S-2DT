using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_gufi_webAPI.Domains;

#nullable disable

namespace senai_gufi_webAPI.Context
{
    public partial class GufiContext : DbContext
    {
        public GufiContext()
        {
        }

        public GufiContext(DbContextOptions<GufiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<ImagemUsuario> ImagemUsuarios { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<Presenca> Presencas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<TipoEvento> TipoEventos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-RSG62TB1\\SQLEXPRESS; Initial Catalog=gufi; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__evento__C8DC7BDAABE374E2");

                entity.ToTable("evento");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.AcessoLivre)
                    .HasColumnName("acessoLivre")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataEvento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEvento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.IdTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeEvento");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__evento__idInstit__5AEE82B9");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__evento__idTipoEv__59FA5E80");
            });

            modelBuilder.Entity<ImagemUsuario>(entity =>
            {
                entity.ToTable("imagemUsuario");

                entity.HasIndex(e => e.IdUsuario, "UQ__imagemUs__645723A7C7017D4A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ImagemUsuario)
                    .HasForeignKey<ImagemUsuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__imagemUsu__idUsu__17036CC0");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB00980B04EA");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.Endereco, "UQ__institui__9456D4068268AF4B")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__institui__AA57D6B4FBA33C3F")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__presenca__44CEA42707AAC6DA");

                entity.ToTable("presenca");

                entity.Property(e => e.IdPresenca).HasColumnName("idPresenca");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__presenca__idEven__00200768");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__presenca__idSitu__01142BA1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__presenca__idUsua__7F2BE32F");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD197FE24A8A0");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.Descricao, "UQ__situacao__91D38C283703EB1C")
                    .IsUnique();

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipo__BDD0DFE130477C53");

                entity.ToTable("tipo");

                entity.HasIndex(e => e.TituloTipoUsario, "UQ__tipo__D1A6DCC5BB8215C9")
                    .IsUnique();

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.TituloTipoUsario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsario");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento)
                    .HasName("PK__tipoEven__09EED93AB15469B9");

                entity.ToTable("tipoEvento");

                entity.HasIndex(e => e.TituloTipoEvento, "UQ__tipoEven__D2A1CBBB05BCC832")
                    .IsUnique();

                entity.Property(e => e.IdTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.TituloTipoEvento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoEvento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6426FED48");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164D06264B4")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__usuario__idTipo__7B5B524B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
