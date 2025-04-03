using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TezgahId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_TezgahId",
                table: "Reçete_Iş_MTM",
                column: "TezgahId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_Tezgah_TezgahId",
                table: "Reçete_Iş_MTM",
                column: "TezgahId",
                principalTable: "Tezgah",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_Tezgah_TezgahId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_TezgahId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "TezgahId",
                table: "Reçete_Iş_MTM");
        }
    }
}
