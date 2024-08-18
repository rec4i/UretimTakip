using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kareKodIsEmris_KareKodUrunlers_BaseProductId",
                table: "kareKodIsEmris");

            migrationBuilder.AddForeignKey(
                name: "FK_kareKodIsEmris_KareKodAnaUruns_BaseProductId",
                table: "kareKodIsEmris",
                column: "BaseProductId",
                principalTable: "KareKodAnaUruns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kareKodIsEmris_KareKodAnaUruns_BaseProductId",
                table: "kareKodIsEmris");

            migrationBuilder.AddForeignKey(
                name: "FK_kareKodIsEmris_KareKodUrunlers_BaseProductId",
                table: "kareKodIsEmris",
                column: "BaseProductId",
                principalTable: "KareKodUrunlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
