using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kareKodIsEmris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedProduct = table.Column<int>(type: "int", nullable: false),
                    PackCount = table.Column<int>(type: "int", nullable: true),
                    BoxCount = table.Column<int>(type: "int", nullable: false),
                    PaletCount = table.Column<int>(type: "int", nullable: false),
                    ProductPerPack = table.Column<int>(type: "int", nullable: true),
                    ProductPerBox = table.Column<int>(type: "int", nullable: true),
                    PackPerBox = table.Column<int>(type: "int", nullable: true),
                    BoxPerPalet = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kareKodIsEmris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kareKodIsEmris_KareKodUrunlers_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "KareKodUrunlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kareKodIsEmris_BaseProductId",
                table: "kareKodIsEmris",
                column: "BaseProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kareKodIsEmris");
        }
    }
}
