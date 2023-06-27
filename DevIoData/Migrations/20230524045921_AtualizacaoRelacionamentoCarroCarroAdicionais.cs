using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoRelacionamentoCarroCarroAdicionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarroAdicionais_Carros_IdCarro",
                table: "CarroAdicionais");

            migrationBuilder.DropIndex(
                name: "IX_CarroAdicionais_IdCarro",
                table: "CarroAdicionais");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "CarroAdicionais");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.CreateTable(
                name: "CarroCarroAdicionais",
                columns: table => new
                {
                    IdCarro = table.Column<int>(type: "int", nullable: false),
                    IdAdicionais = table.Column<int>(type: "int", nullable: false),
                    CarroAdicionaisIdAdicionais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroCarroAdicionais", x => new { x.IdCarro, x.IdAdicionais });
                    table.ForeignKey(
                        name: "FK_CarroCarroAdicionais_CarroAdicionais_CarroAdicionaisIdAdicionais",
                        column: x => x.CarroAdicionaisIdAdicionais,
                        principalTable: "CarroAdicionais",
                        principalColumn: "IdAdicionais");
                    table.ForeignKey(
                        name: "FK_CarroCarroAdicionais_CarroAdicionais_IdAdicionais",
                        column: x => x.IdAdicionais,
                        principalTable: "CarroAdicionais",
                        principalColumn: "IdAdicionais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroCarroAdicionais_Carros_IdCarro",
                        column: x => x.IdCarro,
                        principalTable: "Carros",
                        principalColumn: "IdCarro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroCarroAdicionais_CarroAdicionaisIdAdicionais",
                table: "CarroCarroAdicionais",
                column: "CarroAdicionaisIdAdicionais");

            migrationBuilder.CreateIndex(
                name: "IX_CarroCarroAdicionais_IdAdicionais",
                table: "CarroCarroAdicionais",
                column: "IdAdicionais");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroCarroAdicionais");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Carros",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdCarro",
                table: "CarroAdicionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarroAdicionais_IdCarro",
                table: "CarroAdicionais",
                column: "IdCarro");

            migrationBuilder.AddForeignKey(
                name: "FK_CarroAdicionais_Carros_IdCarro",
                table: "CarroAdicionais",
                column: "IdCarro",
                principalTable: "Carros",
                principalColumn: "IdCarro",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
