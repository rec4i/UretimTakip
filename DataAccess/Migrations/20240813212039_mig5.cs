using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.AlterColumn<string>(
                name: "CariKodu",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Caris",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Row",
                value: 1999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Row",
                value: 1999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Row",
                value: 299);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Row",
                value: 39999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Row",
                value: 2999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Row",
                value: 199999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Row",
                value: 299999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Row",
                value: 3999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Row",
                value: 1999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Row",
                value: 299);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "Row",
                value: 9999);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "Row",
                value: 10999);

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[,]
                {
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Cariler", null, 43, 1, true, null, null, "/Cari/Cariler" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Yönetim", null, null, 3, true, null, null, "#" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Program", null, 59, 1, true, null, null, "/Program/Index" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Üretim", null, null, 3, true, null, null, "#" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Reçete", null, 61, 2, true, null, null, "/Reçete/Index" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Tezgah", null, 61, 3, true, null, null, "/Tezgah/Index" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Iş", null, 61, 4, true, null, null, "/Iş/Index" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Iş Emri", null, 61, 1, true, null, null, "/IşEmri/Index" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Caris");

            migrationBuilder.AlterColumn<string>(
                name: "CariKodu",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Row",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Row",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Row",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Row",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Row",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Row",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Row",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Row",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Row",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Row",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "Row",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "Row",
                value: 10);

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[,]
                {
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Reçete", null, null, 12, true, null, null, "/Reçete/Index" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Tezgah", null, null, 12, true, null, null, "/Tezgah/Index" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Iş", null, null, 12, true, null, null, "/Iş/Index" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Iş Emri", null, null, 12, true, null, null, "/IşEmri/Index" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Program", null, null, 12, true, null, null, "/Program/Index" }
                });
        }
    }
}
