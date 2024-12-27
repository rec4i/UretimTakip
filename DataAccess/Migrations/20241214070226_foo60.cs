using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums");

            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                table: "İşEmriDurums");

            migrationBuilder.AlterColumn<int>(
                name: "İşEmriId",
                table: "İşEmriDurums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TamamlanmaDurum",
                table: "İşEmriDurums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IşId",
                table: "İşEmriDurums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                table: "İşEmriDurums",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums");

            migrationBuilder.DropForeignKey(
                name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                table: "İşEmriDurums");

            migrationBuilder.AlterColumn<int>(
                name: "İşEmriId",
                table: "İşEmriDurums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TamamlanmaDurum",
                table: "İşEmriDurums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IşId",
                table: "İşEmriDurums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_Işs_IşId",
                table: "İşEmriDurums",
                column: "IşId",
                principalTable: "Işs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                table: "İşEmriDurums",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
