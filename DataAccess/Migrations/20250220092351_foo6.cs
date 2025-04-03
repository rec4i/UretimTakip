using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RivaPass",
                table: "SıcakSatışAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RivaUser",
                table: "SıcakSatışAyars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RivaPass",
                table: "SıcakSatışAyars");

            migrationBuilder.DropColumn(
                name: "RivaUser",
                table: "SıcakSatışAyars");
        }
    }
}
