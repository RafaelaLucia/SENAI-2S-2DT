using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spmedicalgroup_webAPI.Domains;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Context
{
    public partial class SPMGContext : DbContext
    {
        public SPMGContext()
        {
        }

        public SPMGContext(DbContextOptions<SPMGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<ImagemUsuario> ImagemUsuarios { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-RSG62TB1\\SQLEXPRESS; Initial Catalog= SP_Medical_Group; user id=sa; pwd=Senai@132;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113A3\\SQLEXPRESS; Initial Catalog= SP_Medical_Group; user id=sa; pwd=senai@132;",
                builder => builder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__C73A60552B96B943");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.Endereco, "UQ__Clinica__9456D406BD3ACB02")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__9BF93A3012C26551")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B4DF0A7751")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

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

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeClinica");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Clinica__idUsuar__0697FACD");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__CA9C61F52AD3D45E");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__idMedi__10216507");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__idPaci__11158940");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__idSitu__0F2D40CE");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidades)
                    .HasName("PK__Especial__972E5EF18669929B");

                entity.Property(e => e.IdEspecialidades)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEspecialidades");

                entity.Property(e => e.DescricaoEspecialidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricaoEspecialidade");
            });

            modelBuilder.Entity<ImagemUsuario>(entity =>
            {
                entity.ToTable("imagemUsuario");

                entity.HasIndex(e => e.IdUsuario, "UQ__imagemUs__645723A73BBF8586")
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

                entity.Property(e => e.Mimetype)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimetype");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ImagemUsuario)
                    .HasForeignKey<ImagemUsuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__imagemUsu__idUsu__6FB49575");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__4E03DEBADB2F7187");

                entity.ToTable("Medico");

                entity.HasIndex(e => e.Crm, "UQ__Medico__C1F887FF7B620FE1")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRM")
                    .IsFixedLength(true);

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidades).HasColumnName("idEspecialidades");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__idClinic__0A688BB1");

                entity.HasOne(d => d.IdEspecialidadesNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidades)
                    .HasConstraintName("FK__Medico__idEspeci__0C50D423");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__idUsuari__0B5CAFEA");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__F48A08F2AC0F8796");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8591BA80A")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F897311A02C639")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.EnderecoPaciente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("enderecoPaciente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomePaciente");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Paciente__idUsua__7B264821");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__12AFD19775F1B823");

                entity.ToTable("Situacao");

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.DescricaoSituacao)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("descricaoSituacao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipoUsua__BDD0DFE11BF6B916");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.DescricaoTipo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("descricaoTipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A60D0679C4");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.EnderecoEmail, "UQ__Usuario__F3FE99E35F32220B")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.EnderecoEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("enderecoEmail");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuario__idTipo__6BE40491");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
