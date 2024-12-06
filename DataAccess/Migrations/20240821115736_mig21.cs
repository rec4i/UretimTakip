using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkOrderId",
                table: "KareKodUrunlers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KareKodUrunlers_WorkOrderId",
                table: "KareKodUrunlers",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodUrunlers_kareKodIsEmris_WorkOrderId",
                table: "KareKodUrunlers",
                column: "WorkOrderId",
                principalTable: "kareKodIsEmris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KareKodUrunlers_kareKodIsEmris_WorkOrderId",
                table: "KareKodUrunlers");

            migrationBuilder.DropIndex(
                name: "IX_KareKodUrunlers_WorkOrderId",
                table: "KareKodUrunlers");

            migrationBuilder.DropColumn(
                name: "WorkOrderId",
                table: "KareKodUrunlers");
        }
    }
}
