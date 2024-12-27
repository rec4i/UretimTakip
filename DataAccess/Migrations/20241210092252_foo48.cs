using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaturaSeriId",
                table: "FaturaBaslıks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeriNo",
                table: "FaturaBaslıks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VergiNo",
                table: "Caris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaturaSeris",
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
                    table.PrimaryKey("PK_FaturaSeris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaSeris_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kasa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    KasaAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KasaKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kasa_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KasaKoduTanıms",
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
                    table.PrimaryKey("PK_KasaKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KasaKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ödemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaBaslıkId = table.Column<int>(type: "int", nullable: false),
                    Açıklama = table.Column<int>(type: "int", nullable: false),
                    ÖdemeTürü = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ödemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ödemes_FaturaBaslıks_FaturaBaslıkId",
                        column: x => x.FaturaBaslıkId,
                        principalTable: "FaturaBaslıks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Kasa Kodu Tanımı", null, 55, 1, true, null, null, "/Tanımlar/KasaKoduTanım" });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_FaturaSeriId",
                table: "FaturaBaslıks",
                column: "FaturaSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaSeris_ProgramŞirketGrupId",
                table: "FaturaSeris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_ProgramŞirketGrupId",
                table: "Kasa",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_KasaKoduTanıms_ProgramŞirketGrupId",
                table: "KasaKoduTanıms",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ödemes_FaturaBaslıkId",
                table: "Ödemes",
                column: "FaturaBaslıkId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaBaslıks_FaturaSeris_FaturaSeriId",
                table: "FaturaBaslıks",
                column: "FaturaSeriId",
                principalTable: "FaturaSeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaBaslıks_FaturaSeris_FaturaSeriId",
                table: "FaturaBaslıks");

            migrationBuilder.DropTable(
                name: "FaturaSeris");

            migrationBuilder.DropTable(
                name: "Kasa");

            migrationBuilder.DropTable(
                name: "KasaKoduTanıms");

            migrationBuilder.DropTable(
                name: "Ödemes");

            migrationBuilder.DropIndex(
                name: "IX_FaturaBaslıks_FaturaSeriId",
                table: "FaturaBaslıks");

            migrationBuilder.DeleteData(
                table: "SideBarMenuItems",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DropColumn(
                name: "FaturaSeriId",
                table: "FaturaBaslıks");

            migrationBuilder.DropColumn(
                name: "SeriNo",
                table: "FaturaBaslıks");

            migrationBuilder.DropColumn(
                name: "VergiNo",
                table: "Caris");
        }
    }
}
