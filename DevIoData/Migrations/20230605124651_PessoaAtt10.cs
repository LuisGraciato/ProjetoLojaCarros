using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_IdCliente",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Funcionarios_IdFuncionario",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_IdCliente",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_IdFuncionario",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Telefones");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Telefones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Telefones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Funcionarios_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Funcionarios_FuncionarioId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Telefones");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdCliente",
                table: "Telefones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdFuncionario",
                table: "Telefones",
                column: "IdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_IdCliente",
                table: "Telefones",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Funcionarios_IdFuncionario",
                table: "Telefones",
                column: "IdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
