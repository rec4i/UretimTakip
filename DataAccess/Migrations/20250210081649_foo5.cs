using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvetHayırSorusu",
                table: "BelgeSorus");

            migrationBuilder.DropColumn(
                name: "SabitAlanYazısı",
                table: "BelgeSorus");

            migrationBuilder.RenameColumn(
                name: "TabloBaşlığı",
                table: "BelgeSorus",
                newName: "Soru");

            migrationBuilder.AddColumn<string>(
                name: "RivaDbYolu",
                table: "SıcakSatışAyars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-right-from-bracket", false, false, false, "Announcement List", null, 34, 12, true, null, null, "/Announcement/AnnouncementList" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DropColumn(
                name: "RivaDbYolu",
                table: "SıcakSatışAyars");

            migrationBuilder.RenameColumn(
                name: "Soru",
                table: "BelgeSorus",
                newName: "TabloBaşlığı");

            migrationBuilder.AddColumn<string>(
                name: "EvetHayırSorusu",
                table: "BelgeSorus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SabitAlanYazısı",
                table: "BelgeSorus",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
