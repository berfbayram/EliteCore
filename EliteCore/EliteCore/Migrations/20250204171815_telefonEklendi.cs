using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCore.Migrations
{
    /// <inheritdoc />
    public partial class telefonEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "GelenMailler",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "GelenMailler");
        }
    }
}
