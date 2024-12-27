using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo70 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YapılacakİşId",
                table: "İşEmriDurums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_YapılacakİşId",
                table: "İşEmriDurums",
                column: "YapılacakİşId");

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

            migrationBuilder.DropIndex(
                name: "IX_İşEmriDurums_YapılacakİşId",
                table: "İşEmriDurums");

            migrationBuilder.DropColumn(
                name: "YapılacakİşId",
                table: "İşEmriDurums");
        }
    }
}
