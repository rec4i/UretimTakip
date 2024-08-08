using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramŞirketGrupId",
                table: "Dosyas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosyas_ProgramŞirketGrupId",
                table: "Dosyas",
                column: "ProgramŞirketGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosyas_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Dosyas",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosyas_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Dosyas");

            migrationBuilder.DropIndex(
                name: "IX_Dosyas_ProgramŞirketGrupId",
                table: "Dosyas");

            migrationBuilder.DropColumn(
                name: "ProgramŞirketGrupId",
                table: "Dosyas");
        }
    }
}
