using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "StokHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepoKodu",
                table: "Depos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CariHarekets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketTürü = table.Column<int>(type: "int", nullable: false),
                    ÖdemeTürü = table.Column<int>(type: "int", nullable: false),
                    ÇekNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ÇekGörselUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariHarekets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariHarekets_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fiyats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeçerliFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeçerliKdvOranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiyats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fiyats_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_CariId",
                table: "StokHarekets",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariHarekets_CariId",
                table: "CariHarekets",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Fiyats_StokId",
                table: "Fiyats",
                column: "StokId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets");

            migrationBuilder.DropTable(
                name: "CariHarekets");

            migrationBuilder.DropTable(
                name: "Fiyats");

            migrationBuilder.DropIndex(
                name: "IX_StokHarekets_CariId",
                table: "StokHarekets");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "StokHarekets");

            migrationBuilder.DropColumn(
                name: "DepoKodu",
                table: "Depos");

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
