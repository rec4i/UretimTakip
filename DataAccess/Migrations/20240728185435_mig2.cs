using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullanılacakDepoId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KullanılacakStokAdeti",
                table: "Reçete_Iş_MTM",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullanılacakStokId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UretilecekDepoId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UretilecekStokAdeti",
                table: "Reçete_Iş_MTM",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UretilecekStokId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "İşAçıklama",
                table: "Reçete_Iş_MTM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakDepoId",
                table: "Reçete_Iş_MTM",
                column: "KullanılacakDepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStokId",
                table: "Reçete_Iş_MTM",
                column: "KullanılacakStokId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_UretilecekDepoId",
                table: "Reçete_Iş_MTM",
                column: "UretilecekDepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_UretilecekStokId",
                table: "Reçete_Iş_MTM",
                column: "UretilecekStokId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Depos_KullanılacakDepoId",
                table: "Reçete_Iş_MTM",
                column: "KullanılacakDepoId",
                principalTable: "Depos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Depos_UretilecekDepoId",
                table: "Reçete_Iş_MTM",
                column: "UretilecekDepoId",
                principalTable: "Depos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Stoks_KullanılacakStokId",
                table: "Reçete_Iş_MTM",
                column: "KullanılacakStokId",
                principalTable: "Stoks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Stoks_UretilecekStokId",
                table: "Reçete_Iş_MTM",
                column: "UretilecekStokId",
                principalTable: "Stoks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Depos_KullanılacakDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Depos_UretilecekDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Stoks_KullanılacakStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Stoks_UretilecekStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_UretilecekDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_UretilecekStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "KullanılacakDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "KullanılacakStokAdeti",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "KullanılacakStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "UretilecekDepoId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "UretilecekStokAdeti",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "UretilecekStokId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "İşAçıklama",
                table: "Reçete_Iş_MTM");
        }
    }
}
