using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IconCss", "IsParent" },
                values: new object[] { "nav-icon fa-solid fa-receipt", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IconCss", "IsParent" },
                values: new object[] { "nav-icon fa-solid fa-right-from-bracket", true });
        }
    }
}
