using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KrediKasaKodu",
                table: "SıcakSatışAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NakitKasaKodu",
                table: "SıcakSatışAyars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KrediKasaKodu",
                table: "SıcakSatışAyars");

            migrationBuilder.DropColumn(
                name: "NakitKasaKodu",
                table: "SıcakSatışAyars");
        }
    }
}
