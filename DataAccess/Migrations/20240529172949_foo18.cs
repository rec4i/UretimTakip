using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uruns_İşEmris_İşEmriId",
                table: "Uruns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uruns",
                table: "Uruns");

            migrationBuilder.RenameTable(
                name: "Uruns",
                newName: "Urun");

            migrationBuilder.RenameIndex(
                name: "IX_Uruns_İşEmriId",
                table: "Urun",
                newName: "IX_Urun_İşEmriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urun",
                table: "Urun",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_İşEmris_İşEmriId",
                table: "Urun",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urun_İşEmris_İşEmriId",
                table: "Urun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urun",
                table: "Urun");

            migrationBuilder.RenameTable(
                name: "Urun",
                newName: "Uruns");

            migrationBuilder.RenameIndex(
                name: "IX_Urun_İşEmriId",
                table: "Uruns",
                newName: "IX_Uruns_İşEmriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uruns",
                table: "Uruns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uruns_İşEmris_İşEmriId",
                table: "Uruns",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
