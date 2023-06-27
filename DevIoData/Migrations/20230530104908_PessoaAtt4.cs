using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoa_IdPessoa",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Pessoa_IdPessoa",
                table: "Telefones");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "Telefones",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_IdPessoa",
                table: "Telefones",
                newName: "IX_Telefones_Id");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "Pessoa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "Enderecos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_IdPessoa",
                table: "Enderecos",
                newName: "IX_Enderecos_Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoa_Id",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Pessoa_Id",
                table: "Telefones");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Telefones",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_Id",
                table: "Telefones",
                newName: "IX_Telefones_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoa",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enderecos",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_Id",
                table: "Enderecos",
                newName: "IX_Enderecos_IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoa_IdPessoa",
                table: "Enderecos",
                column: "IdPessoa",
                principalTable: "Pessoa",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Pessoa_IdPessoa",
                table: "Telefones",
                column: "IdPessoa",
                principalTable: "Pessoa",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
