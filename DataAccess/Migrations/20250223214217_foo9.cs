using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reçete_İş_MTM_DoldurlacakDökümen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reçete_Iş_MTMId = table.Column<int>(type: "int", nullable: true),
                    BelgeId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_İş_MTM_DoldurlacakDökümen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_İş_MTM_DoldurlacakDökümen_Belges_BelgeId",
                        column: x => x.BelgeId,
                        principalTable: "Belges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_İş_MTM_DoldurlacakDökümen_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                        column: x => x.Reçete_Iş_MTMId,
                        principalTable: "Reçete_Iş_MTM",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_İş_MTM_DoldurlacakDökümen_BelgeId",
                table: "Reçete_İş_MTM_DoldurlacakDökümen",
                column: "BelgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_İş_MTM_DoldurlacakDökümen_Reçete_Iş_MTMId",
                table: "Reçete_İş_MTM_DoldurlacakDökümen",
                column: "Reçete_Iş_MTMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reçete_İş_MTM_DoldurlacakDökümen");
        }
    }
}
