using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Funcionarios_IdFuncionario",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_IdCliente",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Funcionarios_IdFuncionario",
                table: "Telefones");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTelefone",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTelefone",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdEndereco",
                table: "Funcionarios",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdTelefone",
                table: "Funcionarios",
                column: "IdTelefone");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTelefone",
                table: "Clientes",
                column: "IdTelefone");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_IdEndereco",
                table: "Clientes",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Telefones_IdTelefone",
                table: "Clientes",
                column: "IdTelefone",
                principalTable: "Telefones",
                principalColumn: "IdTelefone",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Funcionarios_IdFuncionario",
                table: "Enderecos",
                column: "IdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_IdEndereco",
                table: "Funcionarios",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Telefones_IdTelefone",
                table: "Funcionarios",
                column: "IdTelefone",
                principalTable: "Telefones",
                principalColumn: "IdTelefone",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Telefones_IdTelefone",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Funcionarios_IdFuncionario",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_IdEndereco",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Telefones_IdTelefone",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_IdCliente",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Funcionarios_IdFuncionario",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_IdEndereco",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_IdTelefone",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdTelefone",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IdTelefone",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdTelefone",
                table: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Funcionarios_IdFuncionario",
                table: "Enderecos",
                column: "IdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_IdCliente",
                table: "Telefones",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Funcionarios_IdFuncionario",
                table: "Telefones",
                column: "IdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
