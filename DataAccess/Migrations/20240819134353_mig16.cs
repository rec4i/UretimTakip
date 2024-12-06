using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KareKodIstasyons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstasyonAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodIstasyons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodIsEmriIstasyonMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodIsEmriId = table.Column<int>(type: "int", nullable: false),
                    KareKodIstasyonId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodIsEmriIstasyonMTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodIsEmriIstasyonMTMs_kareKodIsEmris_KareKodIsEmriId",
                        column: x => x.KareKodIsEmriId,
                        principalTable: "kareKodIsEmris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KareKodIsEmriIstasyonMTMs_KareKodIstasyons_KareKodIstasyonId",
                        column: x => x.KareKodIstasyonId,
                        principalTable: "KareKodIstasyons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIstasyonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.DropTable(
                name: "KareKodIstasyons");
        }
    }
}
