using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 83,
                column: "ParentId",
                value: 82);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 84,
                column: "ParentId",
                value: 82);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 83,
                column: "ParentId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 84,
                column: "ParentId",
                value: 80);
        }
    }
}
