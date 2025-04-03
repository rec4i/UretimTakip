using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Belges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BelgeSorus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeSoruTürü = table.Column<int>(type: "int", nullable: true),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SabitAlanYazısı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvetHayırSorusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TabloBaşlığı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DahaSonradanEklenebilirmi = table.Column<int>(type: "int", nullable: true),
                    SeçenkelerSeçilebilir = table.Column<int>(type: "int", nullable: true),
                    BelgeId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelgeSorus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BelgeSorus_Belges_BelgeId",
                        column: x => x.BelgeId,
                        principalTable: "Belges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BelgeCevaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeSoruId = table.Column<int>(type: "int", nullable: true),
                    EvetHayırCevap = table.Column<int>(type: "int", nullable: true),
                    TextAreaCevap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarihCevap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelgeCevaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BelgeCevaps_BelgeSorus_BelgeSoruId",
                        column: x => x.BelgeSoruId,
                        principalTable: "BelgeSorus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BelgeSoruSeçeneks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeSoruId = table.Column<int>(type: "int", nullable: true),
                    Seçenek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelgeSoruSeçeneks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BelgeSoruSeçeneks_BelgeSorus_BelgeSoruId",
                        column: x => x.BelgeSoruId,
                        principalTable: "BelgeSorus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BelgeSeçenekCevaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeSoruSeçenekId = table.Column<int>(type: "int", nullable: true),
                    VerilenCevap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelgeSeçenekCevaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BelgeSeçenekCevaps_BelgeSoruSeçeneks_BelgeSoruSeçenekId",
                        column: x => x.BelgeSoruSeçenekId,
                        principalTable: "BelgeSoruSeçeneks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BelgeCevaps_BelgeSoruId",
                table: "BelgeCevaps",
                column: "BelgeSoruId");

            migrationBuilder.CreateIndex(
                name: "IX_BelgeSeçenekCevaps_BelgeSoruSeçenekId",
                table: "BelgeSeçenekCevaps",
                column: "BelgeSoruSeçenekId");

            migrationBuilder.CreateIndex(
                name: "IX_BelgeSorus_BelgeId",
                table: "BelgeSorus",
                column: "BelgeId");

            migrationBuilder.CreateIndex(
                name: "IX_BelgeSoruSeçeneks_BelgeSoruId",
                table: "BelgeSoruSeçeneks",
                column: "BelgeSoruId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BelgeCevaps");

            migrationBuilder.DropTable(
                name: "BelgeSeçenekCevaps");

            migrationBuilder.DropTable(
                name: "BelgeSoruSeçeneks");

            migrationBuilder.DropTable(
                name: "BelgeSorus");

            migrationBuilder.DropTable(
                name: "Belges");
        }
    }
}
