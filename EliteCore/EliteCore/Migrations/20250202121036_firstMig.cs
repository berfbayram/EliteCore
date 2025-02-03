using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCore.Migrations
{
    /// <inheritdoc />
    public partial class firstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GelenMailler",
                columns: table => new
                {
                    GelenMailKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GelenMesaj = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    KullaniciMail = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Ad = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Soyad = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GelenMailler", x => x.GelenMailKod);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GelenMailler_GelenMailKod",
                table: "GelenMailler",
                column: "GelenMailKod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GelenMailler");
        }
    }
}
