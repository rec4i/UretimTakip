using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ÖdemeSeriId",
                table: "FaturaBaslıks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ÖdemeSeris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    SeriNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriTürü = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÖdemeSeris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ÖdemeSeris_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_ÖdemeSeriId",
                table: "FaturaBaslıks",
                column: "ÖdemeSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_ÖdemeSeris_ProgramŞirketGrupId",
                table: "ÖdemeSeris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaBaslıks_ÖdemeSeris_ÖdemeSeriId",
                table: "FaturaBaslıks",
                column: "ÖdemeSeriId",
                principalTable: "ÖdemeSeris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaBaslıks_ÖdemeSeris_ÖdemeSeriId",
                table: "FaturaBaslıks");

            migrationBuilder.DropTable(
                name: "ÖdemeSeris");

            migrationBuilder.DropIndex(
                name: "IX_FaturaBaslıks_ÖdemeSeriId",
                table: "FaturaBaslıks");

            migrationBuilder.DropColumn(
                name: "ÖdemeSeriId",
                table: "FaturaBaslıks");
        }
    }
}
