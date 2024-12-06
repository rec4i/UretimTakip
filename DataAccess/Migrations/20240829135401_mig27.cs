using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BildirimTürü",
                table: "KareKodBildirimEmris",
                newName: "KareKodBildirimTürüId");

            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "KareKodBildirimEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Açıklama",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BildirimDurumu",
                table: "KareKodBildirimEmris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DökümanNo",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DökümanTarihi",
                table: "KareKodBildirimEmris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaturaNo",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KareKodMüşteriId",
                table: "KareKodBildirimEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PtsGönderimDurumu",
                table: "KareKodBildirimEmris",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverDetail",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiparişNo",
                table: "KareKodBildirimEmris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KareKodKolis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodIsEmriId = table.Column<int>(type: "int", nullable: true),
                    PaletSeriNo = table.Column<int>(type: "int", nullable: false),
                    SeriNo = table.Column<int>(type: "int", nullable: false),
                    SSCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodKolis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodKolis_kareKodIsEmris_KareKodIsEmriId",
                        column: x => x.KareKodIsEmriId,
                        principalTable: "kareKodIsEmris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodPalets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodIsEmriId = table.Column<int>(type: "int", nullable: true),
                    SeriNo = table.Column<int>(type: "int", nullable: false),
                    SSCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodPalets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodPalets_kareKodIsEmris_KareKodIsEmriId",
                        column: x => x.KareKodIsEmriId,
                        principalTable: "kareKodIsEmris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimEmris_KareKodBildirimTürüId",
                table: "KareKodBildirimEmris",
                column: "KareKodBildirimTürüId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimEmris_KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris",
                column: "KareKodDeaktivasyonTürüId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimEmris_KareKodMüşteriId",
                table: "KareKodBildirimEmris",
                column: "KareKodMüşteriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodKolis_KareKodIsEmriId",
                table: "KareKodKolis",
                column: "KareKodIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodPalets_KareKodIsEmriId",
                table: "KareKodPalets",
                column: "KareKodIsEmriId");

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodBildirimTürüs_KareKodBildirimTürüId",
                table: "KareKodBildirimEmris",
                column: "KareKodBildirimTürüId",
                principalTable: "KareKodBildirimTürüs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodDeaktivasyonTürüs_KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris",
                column: "KareKodDeaktivasyonTürüId",
                principalTable: "KareKodDeaktivasyonTürüs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodMüşteris_KareKodMüşteriId",
                table: "KareKodBildirimEmris",
                column: "KareKodMüşteriId",
                principalTable: "KareKodMüşteris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodBildirimTürüs_KareKodBildirimTürüId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodDeaktivasyonTürüs_KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropForeignKey(
                name: "FK_KareKodBildirimEmris_KareKodMüşteris_KareKodMüşteriId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropTable(
                name: "KareKodKolis");

            migrationBuilder.DropTable(
                name: "KareKodPalets");

            migrationBuilder.DropIndex(
                name: "IX_KareKodBildirimEmris_KareKodBildirimTürüId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropIndex(
                name: "IX_KareKodBildirimEmris_KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropIndex(
                name: "IX_KareKodBildirimEmris_KareKodMüşteriId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "Adet",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "Açıklama",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "BildirimDurumu",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "DökümanNo",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "DökümanTarihi",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "KareKodDeaktivasyonTürüId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "KareKodMüşteriId",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "PtsGönderimDurumu",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "ReceiverDetail",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "KareKodBildirimEmris");

            migrationBuilder.DropColumn(
                name: "SiparişNo",
                table: "KareKodBildirimEmris");

            migrationBuilder.RenameColumn(
                name: "KareKodBildirimTürüId",
                table: "KareKodBildirimEmris",
                newName: "BildirimTürü");
        }
    }
}
