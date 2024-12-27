using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo63 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM_KullanılacakStoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    KullanılacakStokMiktarı = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM_KullanılacakStoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM_ÜretilecekStoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    ÜretilecekStokMiktarı = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM_ÜretilecekStoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_DepoId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_StokId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_DepoId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_StokId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "StokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM_KullanılacakStoks");

            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM_ÜretilecekStoks");
        }
    }
}
