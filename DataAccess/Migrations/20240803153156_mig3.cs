using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "ParentId",
                value: 46);

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[,]
                {
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Stok", null, null, 3, true, null, null, "#" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Stok", null, 48, 1, true, null, null, "/Stok/Index" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Hızlı Stok Kartı Oluştur", null, 48, 1, true, null, null, "/Stok/HızlıStokKartıOluştur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "ParentId",
                value: 43);

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Stok", null, null, 12, true, null, null, "/Stok/Index" });
        }
    }
}
