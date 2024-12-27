using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Kasa",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Kasa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Kasa");

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Dökümanlar");
        }
    }
}
