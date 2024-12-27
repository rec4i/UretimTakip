using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets");

            migrationBuilder.AlterColumn<int>(
                name: "CariId",
                table: "StokHarekets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets");

            migrationBuilder.AlterColumn<int>(
                name: "CariId",
                table: "StokHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StokHarekets_Caris_CariId",
                table: "StokHarekets",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
