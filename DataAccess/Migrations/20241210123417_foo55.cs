using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramŞirketGrupId",
                table: "FaturaBaslıks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_ProgramŞirketGrupId",
                table: "FaturaBaslıks",
                column: "ProgramŞirketGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaBaslıks_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "FaturaBaslıks",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaBaslıks_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "FaturaBaslıks");

            migrationBuilder.DropIndex(
                name: "IX_FaturaBaslıks_ProgramŞirketGrupId",
                table: "FaturaBaslıks");

            migrationBuilder.DropColumn(
                name: "ProgramŞirketGrupId",
                table: "FaturaBaslıks");
        }
    }
}
