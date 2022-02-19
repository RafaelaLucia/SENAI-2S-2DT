using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace senai_Inlock_webAPI_CodeFirst.Migrations
{
    public partial class meuBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEstudio = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.idEstudio);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    idJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeJogo = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "date", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.idJogo);
                    table.ForeignKey(
                        name: "FK_Jogos_Estudios_idEstudio",
                        column: x => x.idEstudio,
                        principalTable: "Estudios",
                        principalColumn: "idEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    senha = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "idEstudio", "nomeEstudio" },
                values: new object[,]
                {
                    { 1, "Blizzard" },
                    { 2, "Rockstar Studios" },
                    { 3, "Square Enix" }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "idJogo", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um jogo de ação empolgante...", 1, "Diablo III", 99.00m },
                    { 2, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um jogo de ação-aventura...", 2, "Read Dead Redemption II", 120.00m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "senha" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "admin" },
                    { 2, "cliente@cliente.com", 2, "cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_idEstudio",
                table: "Jogos",
                column: "idEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idTipoUsuario",
                table: "Usuarios",
                column: "idTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
