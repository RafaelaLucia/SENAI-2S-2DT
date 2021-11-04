using Microsoft.EntityFrameworkCore;
using senai_Inlock_webAPI_CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Inlock_webAPI_CodeFirst.Context
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre a API e o Banco de dados.
    /// </summary>
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Estudios> Estudios { get; set; }    
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-RSG62TB1\SQLEXPRESS; DataBase=InLock_Games_CodeFirst; user id=sa; pwd=Senai@132");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //(entity => entity.HasIndex(u => u.titulo).IsUnique())
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    idTipoUsuario = 1,
                    titulo = "Administrador"
                },
                new TipoUsuario
                {
                    idTipoUsuario = 2,
                    titulo = "Cliente"
                }
                );
         //-----------------------------------------------------------
            modelBuilder.Entity<Usuarios>().HasData(
                 new Usuarios
                 {
                     idUsuario = 1,
                     email = "admin@admin.com",
                     senha = "admin",
                     idTipoUsuario = 1
                 },
                new Usuarios
                {
                    idUsuario = 2,
                    email = "cliente@cliente.com",
                    senha = "cliente",
                     idTipoUsuario = 2
                }
                );
            //-----------------------------------------------------------
            modelBuilder.Entity<Estudios>().HasData(
                 new Estudios
                 {
                     idEstudio = 1,
                     nomeEstudio = "Blizzard",
                 },
                new Estudios
                {
                    idEstudio = 2,
                    nomeEstudio = "Rockstar Studios",
                },
                new Estudios
                {
                    idEstudio = 3,
                    nomeEstudio = "Square Enix",
                }
                );
            //-----------------------------------------------------------
            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                   idJogo = 1,
                   nomeJogo = "Diablo III",
                   dataLancamento = Convert.ToDateTime("15/05/2012"),
                   descricao = "Um jogo de ação empolgante...",
                   valor = Convert.ToDecimal("99,00"),
                   idEstudio = 1
                },
               new Jogos
               {
                   idJogo = 2,
                   nomeJogo = "Read Dead Redemption II",
                   dataLancamento = Convert.ToDateTime("26/10/2018"),
                   descricao = "Um jogo de ação-aventura...",
                   valor = Convert.ToDecimal("120,00"),
                   idEstudio = 2
               }
               );
            base.OnModelCreating(modelBuilder);
        }
    }
    //Caso tenha que fazer alguma alteração de valores
    //Add-Migration nomedaalteracao = preparou o codigo para criar o banco (mas nao criou)
    
    //Atualizar o banco
    //Update-Database = cria o banco com as informacoes
}
