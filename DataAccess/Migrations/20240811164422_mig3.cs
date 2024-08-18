using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KareKodUrunlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sn = table.Column<long>(type: "bigint", nullable: false),
                    Bn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gtin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Md = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoorId = table.Column<int>(type: "int", nullable: false),
                    PaletSn = table.Column<int>(type: "int", nullable: false),
                    BoxSn = table.Column<int>(type: "int", nullable: false),
                    PackSn = table.Column<int>(type: "int", nullable: false),
                    PaletSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodUrunlers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KareKodUrunlers");
        }
    }
}
