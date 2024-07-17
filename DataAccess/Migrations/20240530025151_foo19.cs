using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class foo19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urun_İşEmris_İşEmriId",
                table: "Urun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urun",
                table: "Urun");

            migrationBuilder.RenameTable(
                name: "Urun",
                newName: "Uruns");

            migrationBuilder.RenameIndex(
                name: "IX_Urun_İşEmriId",
                table: "Uruns",
                newName: "IX_Uruns_İşEmriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uruns",
                table: "Uruns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UrunAşamalarıs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    IşId = table.Column<int>(type: "int", nullable: true),
                    İşEmriId = table.Column<int>(type: "int", nullable: true),
                    İşeBaşlamaZamanı = table.Column<DateTime>(type: "datetime2", nullable: true),
                    İşiBitirmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: true),
                    İşiÜstlenenKullanıcıId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TamamlanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunAşamalarıs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_AspNetUsers_İşiÜstlenenKullanıcıId",
                        column: x => x.İşiÜstlenenKullanıcıId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_Işs_IşId",
                        column: x => x.IşId,
                        principalTable: "Işs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_İşEmris_İşEmriId",
                        column: x => x.İşEmriId,
                        principalTable: "İşEmris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_Uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Uruns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrunAşamalarıs_IşId",
                table: "UrunAşamalarıs",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunAşamalarıs_İşEmriId",
                table: "UrunAşamalarıs",
                column: "İşEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunAşamalarıs_İşiÜstlenenKullanıcıId",
                table: "UrunAşamalarıs",
                column: "İşiÜstlenenKullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunAşamalarıs_UrunId",
                table: "UrunAşamalarıs",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uruns_İşEmris_İşEmriId",
                table: "Uruns",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uruns_İşEmris_İşEmriId",
                table: "Uruns");

            migrationBuilder.DropTable(
                name: "UrunAşamalarıs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uruns",
                table: "Uruns");

            migrationBuilder.RenameTable(
                name: "Uruns",
                newName: "Urun");

            migrationBuilder.RenameIndex(
                name: "IX_Uruns_İşEmriId",
                table: "Urun",
                newName: "IX_Urun_İşEmriId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urun",
                table: "Urun",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_İşEmris_İşEmriId",
                table: "Urun",
                column: "İşEmriId",
                principalTable: "İşEmris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
