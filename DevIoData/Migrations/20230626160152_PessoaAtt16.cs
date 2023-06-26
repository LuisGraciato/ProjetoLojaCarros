using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    public partial class PessoaAtt16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroAdicionais",
                columns: table => new
                {
                    IdCarroAdicionais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarro = table.Column<int>(type: "int", nullable: false),
                    IdAdicionais = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroAdicionais", x => x.IdCarroAdicionais);
                    table.ForeignKey(
                        name: "FK_CarroAdicionais_Adicionais_IdAdicionais",
                        column: x => x.IdAdicionais,
                        principalTable: "Adicionais",
                        principalColumn: "IdAdicionais",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_CarroAdicionais_IdCarro",
                table: "CarroAdicionais",
                column: "IdCarro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroAdicionais");
        }
    }
}
