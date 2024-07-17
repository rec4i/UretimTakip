using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeFzgahId",
                table: "Işs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TezgahId",
                table: "Işs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Işs_TezgahId",
                table: "Işs",
                column: "TezgahId");

            migrationBuilder.AddForeignKey(
                name: "FK_Işs_Tezgah_TezgahId",
                table: "Işs",
                column: "TezgahId",
                principalTable: "Tezgah",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Işs_Tezgah_TezgahId",
                table: "Işs");

            migrationBuilder.DropIndex(
                name: "IX_Işs_TezgahId",
                table: "Işs");

            migrationBuilder.DropColumn(
                name: "TeFzgahId",
                table: "Işs");

            migrationBuilder.DropColumn(
                name: "TezgahId",
                table: "Işs");
        }
    }
}
