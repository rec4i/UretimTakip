using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepoKoduTanıms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    Tanım = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepoKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepoKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepoKoduTanıms_ProgramŞirketGrupId",
                table: "DepoKoduTanıms",
                column: "ProgramŞirketGrupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepoKoduTanıms");
        }
    }
}
