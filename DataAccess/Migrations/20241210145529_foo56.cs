using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramŞirketGrupId",
                table: "Ödemes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriNo",
                table: "Ödemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ÖdemeSeriId",
                table: "Ödemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ödemes_ÖdemeSeriId",
                table: "Ödemes",
                column: "ÖdemeSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_Ödemes_ProgramŞirketGrupId",
                table: "Ödemes",
                column: "ProgramŞirketGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ödemes_ÖdemeSeris_ÖdemeSeriId",
                table: "Ödemes",
                column: "ÖdemeSeriId",
                principalTable: "ÖdemeSeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ödemes_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Ödemes",
                column: "ProgramŞirketGrupId",
                principalTable: "ProgramŞirketGrups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ödemes_ÖdemeSeris_ÖdemeSeriId",
                table: "Ödemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ödemes_ProgramŞirketGrups_ProgramŞirketGrupId",
                table: "Ödemes");

            migrationBuilder.DropIndex(
                name: "IX_Ödemes_ÖdemeSeriId",
                table: "Ödemes");

            migrationBuilder.DropIndex(
                name: "IX_Ödemes_ProgramŞirketGrupId",
                table: "Ödemes");

            migrationBuilder.DropColumn(
                name: "ProgramŞirketGrupId",
                table: "Ödemes");

            migrationBuilder.DropColumn(
                name: "SeriNo",
                table: "Ödemes");

            migrationBuilder.DropColumn(
                name: "ÖdemeSeriId",
                table: "Ödemes");
        }
    }
}
