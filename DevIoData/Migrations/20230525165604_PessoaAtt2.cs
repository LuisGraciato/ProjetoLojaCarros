using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIoData.Migrations
{
    /// <inheritdoc />
    public partial class PessoaAtt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");
        }
    }
}
