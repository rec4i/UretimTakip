using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmris_Reçetes_ReçeteId",
                table: "İşEmris");

            migrationBuilder.DropIndex(
                name: "IX_İşEmris_ReçeteId",
                table: "İşEmris");

            migrationBuilder.AddColumn<int>(
                name: "İşEmriId",
                table: "Reçetes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reçetes_İşEmriId",
                table: "Reçetes",
                column: "İşEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reçetes_İşEmris_İşEmriId",
                table: "Reçetes",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reçetes_İşEmris_İşEmriId",
                table: "Reçetes");

            migrationBuilder.DropIndex(
                name: "IX_Reçetes_İşEmriId",
                table: "Reçetes");

            migrationBuilder.DropColumn(
                name: "İşEmriId",
                table: "Reçetes");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmris_ReçeteId",
                table: "İşEmris",
                column: "ReçeteId");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmris_Reçetes_ReçeteId",
                table: "İşEmris",
                column: "ReçeteId",
                principalTable: "Reçetes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
