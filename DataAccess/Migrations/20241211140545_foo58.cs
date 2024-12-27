using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo58 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaturaBaslıkId",
                table: "StokHarekets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_FaturaBaslıkId",
                table: "StokHarekets",
                column: "FaturaBaslıkId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHarekets_FaturaBaslıks_FaturaBaslıkId",
                table: "StokHarekets",
                column: "FaturaBaslıkId",
                principalTable: "FaturaBaslıks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHarekets_FaturaBaslıks_FaturaBaslıkId",
                table: "StokHarekets");

            migrationBuilder.DropIndex(
                name: "IX_StokHarekets_FaturaBaslıkId",
                table: "StokHarekets");

            migrationBuilder.DropColumn(
                name: "FaturaBaslıkId",
                table: "StokHarekets");
        }
    }
}
