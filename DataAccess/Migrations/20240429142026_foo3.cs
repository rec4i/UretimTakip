using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Işs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IşAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Işs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reçetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SıraId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tezgah",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TezgahAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tezgah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İşEmris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: false),
                    HedefÜretim = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşEmris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İşEmris_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: true),
                    IşId = table.Column<int>(type: "int", nullable: true),
                    TezgahId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_Işs_IşId",
                        column: x => x.IşId,
                        principalTable: "Işs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Tezgah_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: true),
                    TezgahId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Tezgah_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Tezgah_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Tezgah_MTM_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-right-from-bracket", false, false, true, "Reçete", null, null, 12, true, null, null, "/Reçete/Index" });

            migrationBuilder.CreateIndex(
                name: "IX_İşEmris_ReçeteId",
                table: "İşEmris",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_IşId",
                table: "Reçete_Iş_MTM",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ReçeteId",
                table: "Reçete_Iş_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_TezgahId",
                table: "Reçete_Iş_MTM",
                column: "TezgahId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Tezgah_MTM_ReçeteId",
                table: "Reçete_Tezgah_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Tezgah_MTM_TezgahId",
                table: "Reçete_Tezgah_MTM",
                column: "TezgahId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İşEmris");

            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM");

            migrationBuilder.DropTable(
                name: "Reçete_Tezgah_MTM");

            migrationBuilder.DropTable(
                name: "Işs");

            migrationBuilder.DropTable(
                name: "Reçetes");

            migrationBuilder.DropTable(
                name: "Tezgah");

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
