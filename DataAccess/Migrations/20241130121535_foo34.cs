using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Birims_BirimId",
                table: "Stoks");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "Stoks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Birims_BirimId",
                table: "Stoks",
                column: "BirimId",
                principalTable: "Birims",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Birims_BirimId",
                table: "Stoks");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "Stoks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Birims_BirimId",
                table: "Stoks",
                column: "BirimId",
                principalTable: "Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
