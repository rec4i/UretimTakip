using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo68 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HedefBaşlamaTarihi",
                table: "İşEmris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HedefBitişTarihi",
                table: "İşEmris",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HedefBaşlamaTarihi",
                table: "İşEmris");

            migrationBuilder.DropColumn(
                name: "HedefBitişTarihi",
                table: "İşEmris");
        }
    }
}
