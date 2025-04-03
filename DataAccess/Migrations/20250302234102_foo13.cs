using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StokHareketId",
                table: "FaturaDetay",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_StokHareketId",
                table: "FaturaDetay",
                column: "StokHareketId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaDetay_StokHarekets_StokHareketId",
                table: "FaturaDetay",
                column: "StokHareketId",
                principalTable: "StokHarekets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaDetay_StokHarekets_StokHareketId",
                table: "FaturaDetay");

            migrationBuilder.DropIndex(
                name: "IX_FaturaDetay_StokHareketId",
                table: "FaturaDetay");

            migrationBuilder.DropColumn(
                name: "StokHareketId",
                table: "FaturaDetay");
        }
    }
}
