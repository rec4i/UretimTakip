using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ŞantiyeId",
                table: "BlokBilgis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Şantiyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Şantiyes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Şantiye", null, null, 3, true, null, null, "#" });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Şantiyeler", null, 43, 1, true, null, null, "/Şantiye/Index" });

            migrationBuilder.CreateIndex(
                name: "IX_BlokBilgis_ŞantiyeId",
                table: "BlokBilgis",
                column: "ŞantiyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlokBilgis_Şantiyes_ŞantiyeId",
                table: "BlokBilgis",
                column: "ŞantiyeId",
                principalTable: "Şantiyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlokBilgis_Şantiyes_ŞantiyeId",
                table: "BlokBilgis");

            migrationBuilder.DropTable(
                name: "Şantiyes");

            migrationBuilder.DropIndex(
                name: "IX_BlokBilgis_ŞantiyeId",
                table: "BlokBilgis");

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DropColumn(
                name: "ŞantiyeId",
                table: "BlokBilgis");
        }
    }
}
