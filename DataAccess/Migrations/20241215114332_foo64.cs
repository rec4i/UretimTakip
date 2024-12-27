using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "Reçete_Iş_MTMId",
                principalTable: "Reçete_Iş_MTM",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "Reçete_Iş_MTMId",
                principalTable: "Reçete_Iş_MTM",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks");

            migrationBuilder.DropColumn(
                name: "Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks");

            migrationBuilder.DropColumn(
                name: "Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks");
        }
    }
}
