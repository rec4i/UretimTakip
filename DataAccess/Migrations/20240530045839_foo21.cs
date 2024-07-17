using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tezgah_Iş_MTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TezgahId = table.Column<int>(type: "int", nullable: false),
                    IşId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tezgah_Iş_MTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tezgah_Iş_MTMs_Işs_IşId",
                        column: x => x.IşId,
                        principalTable: "Işs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tezgah_Iş_MTMs_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tezgah_Iş_MTMs_IşId",
                table: "Tezgah_Iş_MTMs",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_Tezgah_Iş_MTMs_TezgahId",
                table: "Tezgah_Iş_MTMs",
                column: "TezgahId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tezgah_Iş_MTMs");
        }
    }
}
