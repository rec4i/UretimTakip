using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Tezgah_TezgahId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_TezgahId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "TezgahId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "TeFzgahId",
                table: "Işs");

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Iş Emri", null, null, 12, true, null, null, "/IşEmri/Index" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.AddColumn<int>(
                name: "TezgahId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeFzgahId",
                table: "Işs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_TezgahId",
                table: "Reçete_Iş_MTM",
                column: "TezgahId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Tezgah_TezgahId",
                table: "Reçete_Iş_MTM",
                column: "TezgahId",
                principalTable: "Tezgah",
                principalColumn: "Id");
        }
    }
}
