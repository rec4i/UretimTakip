using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DosyaİndirmeYetkis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaİndirmeYetkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaİndirmeYetkis_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaİndirmeYetkis_Dosyas_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DosyaİsimDeğiştirmeYetkis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaİsimDeğiştirmeYetkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaİsimDeğiştirmeYetkis_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaİsimDeğiştirmeYetkis_Dosyas_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DosyaSilmeYetkis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaSilmeYetkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaSilmeYetkis_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaSilmeYetkis_Dosyas_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DosyaYetkiYetkis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaYetkiYetkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaYetkiYetkis_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaYetkiYetkis_Dosyas_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİndirmeYetkis_DosyaId",
                table: "DosyaİndirmeYetkis",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİndirmeYetkis_UserId",
                table: "DosyaİndirmeYetkis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİsimDeğiştirmeYetkis_DosyaId",
                table: "DosyaİsimDeğiştirmeYetkis",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİsimDeğiştirmeYetkis_UserId",
                table: "DosyaİsimDeğiştirmeYetkis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaSilmeYetkis_DosyaId",
                table: "DosyaSilmeYetkis",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaSilmeYetkis_UserId",
                table: "DosyaSilmeYetkis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaYetkiYetkis_DosyaId",
                table: "DosyaYetkiYetkis",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaYetkiYetkis_UserId",
                table: "DosyaYetkiYetkis",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosyaİndirmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaİsimDeğiştirmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaSilmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaYetkiYetkis");
        }
    }
}
