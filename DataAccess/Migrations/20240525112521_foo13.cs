using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SıraId",
                table: "Reçetes");

            migrationBuilder.AddColumn<string>(
                name: "Açıklama",
                table: "Reçetes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Reçete_Stok_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    KullanılacakAdet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Stok_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Stok_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reçete_Stok_MTM_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Stok_MTM_ReçeteId",
                table: "Reçete_Stok_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Stok_MTM_StokId",
                table: "Reçete_Stok_MTM",
                column: "StokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reçete_Stok_MTM");

            migrationBuilder.DropColumn(
                name: "Açıklama",
                table: "Reçetes");

            migrationBuilder.AddColumn<int>(
                name: "SıraId",
                table: "Reçetes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
