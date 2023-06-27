using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoa_Id",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Pessoa_Id",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Telefones",
                newName: "IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_Id",
                table: "Telefones",
                newName: "IX_Telefones_IdFuncionario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enderecos",
                newName: "IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_Id",
                table: "Enderecos",
                newName: "IX_Enderecos_IdFuncionario");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdCliente",
                table: "Telefones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos",
                column: "IdCliente");

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

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_IdCliente",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "Telefones",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_IdFuncionario",
                table: "Telefones",
                newName: "IX_Telefones_Id");

            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "Enderecos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_IdFuncionario",
                table: "Enderecos",
                newName: "IX_Enderecos_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoa_Id",
                table: "Enderecos",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Pessoa_Id",
                table: "Telefones",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
