using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Telefones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Telefones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Enderecos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Enderecos");
        }
    }
}
