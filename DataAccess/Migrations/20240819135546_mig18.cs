using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KareKodIsEmriIstasyonMTMs_kareKodIsEmris_KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_KareKodIsEmriIstasyonMTMs_KareKodIstasyons_KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.DropIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.DropIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.AddColumn<int>(
                name: "KareKodIsEmriIstasyonMTMId",
                table: "KareKodIstasyons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KareKodIsEmriIstasyonMTMId",
                table: "kareKodIsEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIstasyons_KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons",
                column: "KareKodIsEmriIstasyonMTMId1");

            migrationBuilder.CreateIndex(
                name: "IX_kareKodIsEmris_KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris",
                column: "KareKodIsEmriIstasyonMTMId1");

            migrationBuilder.AddForeignKey(
                name: "FK_kareKodIsEmris_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris",
                column: "KareKodIsEmriIstasyonMTMId1",
                principalTable: "KareKodIsEmriIstasyonMTMs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodIstasyons_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons",
                column: "KareKodIsEmriIstasyonMTMId1",
                principalTable: "KareKodIsEmriIstasyonMTMs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kareKodIsEmris_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris");

            migrationBuilder.DropForeignKey(
                name: "FK_KareKodIstasyons_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons");

            migrationBuilder.DropIndex(
                name: "IX_KareKodIstasyons_KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons");

            migrationBuilder.DropIndex(
                name: "IX_kareKodIsEmris_KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris");

            migrationBuilder.DropColumn(
                name: "KareKodIsEmriIstasyonMTMId",
                table: "KareKodIstasyons");

            migrationBuilder.DropColumn(
                name: "KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons");

            migrationBuilder.DropColumn(
                name: "KareKodIsEmriIstasyonMTMId",
                table: "kareKodIsEmris");

            migrationBuilder.DropColumn(
                name: "KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris");

            migrationBuilder.AlterColumn<int>(
                name: "KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIsEmriIstasyonMTMs_KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIstasyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodIsEmriIstasyonMTMs_kareKodIsEmris_KareKodIsEmriId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIsEmriId",
                principalTable: "kareKodIsEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodIsEmriIstasyonMTMs_KareKodIstasyons_KareKodIstasyonId",
                table: "KareKodIsEmriIstasyonMTMs",
                column: "KareKodIstasyonId",
                principalTable: "KareKodIstasyons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
