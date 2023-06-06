using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adicionais",
                columns: table => new
                {
                    IdAdicionais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionais", x => x.IdAdicionais);
                });

            migrationBuilder.CreateTable(
                name: "CarroAdicionais",
                columns: table => new
                {
                    IdCarro = table.Column<int>(type: "int", nullable: false),
                    IdAdicionais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroAdicionais", x => new { x.IdCarro, x.IdAdicionais });
                    table.ForeignKey(
                        name: "FK_CarroAdicionais_Adicionais_IdAdicionais",
                        column: x => x.IdAdicionais,
                        principalTable: "Adicionais",
                        principalColumn: "IdAdicionais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroAdicionais_Carros_IdCarro",
                        column: x => x.IdCarro,
                        principalTable: "Carros",
                        principalColumn: "IdCarro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroAdicionais_IdAdicionais",
                table: "CarroAdicionais",
                column: "IdAdicionais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroAdicionais");

            migrationBuilder.DropTable(
                name: "Adicionais");
        }
    }
}
