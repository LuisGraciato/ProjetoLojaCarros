using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Carros_IdCarro",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdCarro",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "Vendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCarro",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdCarro",
                table: "Vendas",
                column: "IdCarro");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Carros_IdCarro",
                table: "Vendas",
                column: "IdCarro",
                principalTable: "Carros",
                principalColumn: "IdCarro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
