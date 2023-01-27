using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWebGradesApplication.Migrations
{
    public partial class CriarBaseDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formadores",
                columns: table => new
                {
                    Nif = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formadores", x => x.Nif);
                });

            migrationBuilder.CreateTable(
                name: "Formandos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formandos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ufcds",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Ufcd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Componente = table.Column<int>(type: "int", nullable: false),
                    FormadorNif = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ufcds", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Ufcds_Formadores_FormadorNif",
                        column: x => x.FormadorNif,
                        principalTable: "Formadores",
                        principalColumn: "Nif",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    CodigoUfcd = table.Column<int>(type: "int", nullable: false),
                    FormandoId = table.Column<int>(type: "int", nullable: false),
                    DataLancamentoNota = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => new { x.FormandoId, x.CodigoUfcd });
                    table.ForeignKey(
                        name: "FK_Notas_Formandos_FormandoId",
                        column: x => x.FormandoId,
                        principalTable: "Formandos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Ufcds_CodigoUfcd",
                        column: x => x.CodigoUfcd,
                        principalTable: "Ufcds",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_CodigoUfcd",
                table: "Notas",
                column: "CodigoUfcd");

            migrationBuilder.CreateIndex(
                name: "IX_Ufcds_FormadorNif",
                table: "Ufcds",
                column: "FormadorNif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Formandos");

            migrationBuilder.DropTable(
                name: "Ufcds");

            migrationBuilder.DropTable(
                name: "Formadores");
        }
    }
}
