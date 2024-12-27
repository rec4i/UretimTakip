using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaDetay_Birims_BirimId",
                table: "FaturaDetay");

            migrationBuilder.DropIndex(
                name: "IX_FaturaDetay_BirimId",
                table: "FaturaDetay");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "FaturaDetay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "FaturaDetay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_BirimId",
                table: "FaturaDetay",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaDetay_Birims_BirimId",
                table: "FaturaDetay",
                column: "BirimId",
                principalTable: "Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
