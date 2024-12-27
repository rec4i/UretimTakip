using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "UretilecekStokId",
                table: "Reçete_Iş_MTM",
                newName: "İşTamamlanmaSüresi");

            migrationBuilder.AddColumn<int>(
                name: "Reçete_Iş_MTMId",
                table: "İşEmriDurums",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "İşTamamlanmaSüresi",
                table: "Işs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_Reçete_Iş_MTMId",
                table: "İşEmriDurums",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "İşEmriDurums",
                column: "Reçete_Iş_MTMId",
                principalTable: "Reçete_Iş_MTM",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                table: "İşEmriDurums");

            migrationBuilder.DropIndex(
                name: "IX_İşEmriDurums_Reçete_Iş_MTMId",
                table: "İşEmriDurums");

            migrationBuilder.DropColumn(
                name: "Reçete_Iş_MTMId",
                table: "İşEmriDurums");

            migrationBuilder.DropColumn(
                name: "İşTamamlanmaSüresi",
                table: "Işs");

            migrationBuilder.RenameColumn(
                name: "İşTamamlanmaSüresi",
                table: "Reçete_Iş_MTM",
                newName: "UretilecekStokId");

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
    }
}
