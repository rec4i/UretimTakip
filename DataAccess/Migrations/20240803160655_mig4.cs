using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StokKodu",
                table: "Stoks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CariKodu",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CariKoduTanıms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    Tanım = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StokKoduTanıms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    Tanım = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CariKoduTanıms_ProgramŞirketGrupId",
                table: "CariKoduTanıms",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_StokKoduTanıms_ProgramŞirketGrupId",
                table: "StokKoduTanıms",
                column: "ProgramŞirketGrupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CariKoduTanıms");

            migrationBuilder.DropTable(
                name: "StokKoduTanıms");

            migrationBuilder.DropColumn(
                name: "StokKodu",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "CariKodu",
                table: "Caris");
        }
    }
}
