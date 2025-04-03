using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RivaFaturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BelgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RivaFaturaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RivaFaturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RivaFaturaSatırs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RivaFaturaId = table.Column<int>(type: "int", nullable: true),
                    RivaFaturaSatırId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenelTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    birimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iskonto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ürünId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ÜrünAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RivaFaturaSatırs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RivaFaturaSatırs_RivaFaturas_RivaFaturaId",
                        column: x => x.RivaFaturaId,
                        principalTable: "RivaFaturas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RivaFaturaSatırs_RivaFaturaId",
                table: "RivaFaturaSatırs",
                column: "RivaFaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RivaFaturaSatırs");

            migrationBuilder.DropTable(
                name: "RivaFaturas");
        }
    }
}
