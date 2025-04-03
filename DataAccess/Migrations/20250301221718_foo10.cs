using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "İşEmriDurumId",
                table: "StokHarekets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_İşEmriDurumId",
                table: "StokHarekets",
                column: "İşEmriDurumId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHarekets_İşEmriDurums_İşEmriDurumId",
                table: "StokHarekets",
                column: "İşEmriDurumId",
                principalTable: "İşEmriDurums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHarekets_İşEmriDurums_İşEmriDurumId",
                table: "StokHarekets");

            migrationBuilder.DropIndex(
                name: "IX_StokHarekets_İşEmriDurumId",
                table: "StokHarekets");

            migrationBuilder.DropColumn(
                name: "İşEmriDurumId",
                table: "StokHarekets");
        }
    }
}
