using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İşEmriDurums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İşEmriId = table.Column<int>(type: "int", nullable: false),
                    TamamlanmaDurum = table.Column<int>(type: "int", nullable: false),
                    IşId = table.Column<int>(type: "int", nullable: false),
                    BaşlamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitişTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşEmriDurums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İşEmriDurums_Işs_IşId",
                        column: x => x.IşId,
                        principalTable: "Işs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                        column: x => x.İşEmriId,
                        principalTable: "İşEmris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_IşId",
                table: "İşEmriDurums",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_İşEmriId",
                table: "İşEmriDurums",
                column: "İşEmriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İşEmriDurums");
        }
    }
}
