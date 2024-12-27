using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM",
                column: "SorumluKullanıcıGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçete_Iş_MTM_SorumluKullanıcıGrups_SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM",
                column: "SorumluKullanıcıGrupId",
                principalTable: "SorumluKullanıcıGrups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçete_Iş_MTM_SorumluKullanıcıGrups_SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropIndex(
                name: "IX_Reçete_Iş_MTM_SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM");

            migrationBuilder.DropColumn(
                name: "SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM");
        }
    }
}
