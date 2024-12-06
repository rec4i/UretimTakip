using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KareKodBildirimStokMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodBildirimEmriId = table.Column<int>(type: "int", nullable: true),
                    KareKodStokId = table.Column<int>(type: "int", nullable: true),
                    BildirimDurumu = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodBildirimStokMTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimStokMTMs_KareKodBildirimEmris_KareKodBildirimEmriId",
                        column: x => x.KareKodBildirimEmriId,
                        principalTable: "KareKodBildirimEmris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KareKodBildirimStokMTMs_KareKodStoks_KareKodStokId",
                        column: x => x.KareKodStokId,
                        principalTable: "KareKodStoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimStokMTMs_KareKodBildirimEmriId",
                table: "KareKodBildirimStokMTMs",
                column: "KareKodBildirimEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimStokMTMs_KareKodStokId",
                table: "KareKodBildirimStokMTMs",
                column: "KareKodStokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KareKodBildirimStokMTMs");
        }
    }
}
