using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums");

            migrationBuilder.RenameColumn(
                name: "IşId",
                table: "İşEmriDurums",
                newName: "YapılacakİşId");

            migrationBuilder.RenameIndex(
                name: "IX_İşEmriDurums_IşId",
                table: "İşEmriDurums",
                newName: "IX_İşEmriDurums_YapılacakİşId");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Işs_YapılacakİşId",
                table: "İşEmriDurums",
                column: "YapılacakİşId",
                principalTable: "Işs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Işs_YapılacakİşId",
                table: "İşEmriDurums");

            migrationBuilder.RenameColumn(
                name: "YapılacakİşId",
                table: "İşEmriDurums",
                newName: "IşId");

            migrationBuilder.RenameIndex(
                name: "IX_İşEmriDurums_YapılacakİşId",
                table: "İşEmriDurums",
                newName: "IX_İşEmriDurums_IşId");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id");
        }
    }
}
