using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo71 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Işs_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Işs");

            migrationBuilder.DropForeignKey(
                name: "FK_Işs_Tezgah_TezgahId",
                table: "Işs");

            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Işs_YapılacakİşId",
                table: "İşEmriDurums");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Işs_IşId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropForeignKey(
                name: "FK_Tezgah_Iş_MTMs_Işs_IşId",
                table: "Tezgah_Iş_MTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunAşamalarıs_Işs_IşId",
                table: "UrunAşamalarıs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Işs",
                table: "Işs");

            migrationBuilder.RenameTable(
                name: "Işs",
                newName: "İşs");

            migrationBuilder.RenameIndex(
                name: "IX_Işs_TezgahId",
                table: "İşs",
                newName: "IX_İşs_TezgahId");

            migrationBuilder.RenameIndex(
                name: "IX_Işs_ProgramŞirketGrupId",
                table: "İşs",
                newName: "IX_İşs_ProgramŞirketGrupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_İşs",
                table: "İşs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_İşs_YapılacakİşId",
                table: "İşEmriDurums",
                column: "YapılacakİşId",
                principalTable: "İşs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_İşs_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "İşs",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_İşs_Tezgah_TezgahId",
                table: "İşs",
                column: "TezgahId",
                principalTable: "Tezgah",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_İşs_IşId",
                table: "Reçete_Iş_MTM",
                column: "IşId",
                principalTable: "İşs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tezgah_Iş_MTMs_İşs_IşId",
                table: "Tezgah_Iş_MTMs",
                column: "IşId",
                principalTable: "İşs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunAşamalarıs_İşs_IşId",
                table: "UrunAşamalarıs",
                column: "IşId",
                principalTable: "İşs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_İşs_YapılacakİşId",
                table: "İşEmriDurums");

            migrationBuilder.DropForeignKey(
                name: "FK_İşs_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "İşs");

            migrationBuilder.DropForeignKey(
                name: "FK_İşs_Tezgah_TezgahId",
                table: "İşs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_İşs_IşId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropForeignKey(
                name: "FK_Tezgah_Iş_MTMs_İşs_IşId",
                table: "Tezgah_Iş_MTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunAşamalarıs_İşs_IşId",
                table: "UrunAşamalarıs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_İşs",
                table: "İşs");

            migrationBuilder.RenameTable(
                name: "İşs",
                newName: "Işs");

            migrationBuilder.RenameIndex(
                name: "IX_İşs_TezgahId",
                table: "Işs",
                newName: "IX_Işs_TezgahId");

            migrationBuilder.RenameIndex(
                name: "IX_İşs_ProgramŞirketGrupId",
                table: "Işs",
                newName: "IX_Işs_ProgramŞirketGrupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Işs",
                table: "Işs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Işs_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Işs",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Işs_Tezgah_TezgahId",
                table: "Işs",
                column: "TezgahId",
                principalTable: "Tezgah",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Işs_YapılacakİşId",
                table: "İşEmriDurums",
                column: "YapılacakİşId",
                principalTable: "Işs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Işs_IşId",
                table: "Reçete_Iş_MTM",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tezgah_Iş_MTMs_Işs_IşId",
                table: "Tezgah_Iş_MTMs",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunAşamalarıs_Işs_IşId",
                table: "UrunAşamalarıs",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id");
        }
    }
}
