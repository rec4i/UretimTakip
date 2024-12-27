using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramŞirketGrupId",
                table: "Barkods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Barkods_ProgramŞirketGrupId",
                table: "Barkods",
                column: "ProgramŞirketGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barkods_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Barkods",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barkods_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Barkods");

            migrationBuilder.DropIndex(
                name: "IX_Barkods_ProgramŞirketGrupId",
                table: "Barkods");

            migrationBuilder.DropColumn(
                name: "ProgramŞirketGrupId",
                table: "Barkods");
        }
    }
}
