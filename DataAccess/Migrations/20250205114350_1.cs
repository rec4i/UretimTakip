using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BanStatus = table.Column<bool>(type: "bit", nullable: false),
                    BanStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BanEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BanComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DönüşümKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DönüşümAçıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjecTtype = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosyas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    DosyaAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dökümans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dökümans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodAnaUruns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gtin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<int>(type: "int", nullable: true),
                    RafCycleTime = table.Column<int>(type: "int", nullable: false),
                    RafCycleUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxesInPalet = table.Column<int>(type: "int", nullable: true),
                    ProductInBox = table.Column<int>(type: "int", nullable: true),
                    ProductsInPack = table.Column<int>(type: "int", nullable: true),
                    PacksInBox = table.Column<int>(type: "int", nullable: true),
                    HasPack = table.Column<bool>(type: "bit", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodAnaUruns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodBildirimTürüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BildirimTürü = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BildirimTürüKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodBildirimTürüs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodDeaktivasyonTürüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeaktivasyonKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sebep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodDeaktivasyonTürüs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodIsEmriIstasyonMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodIsEmriId = table.Column<int>(type: "int", nullable: true),
                    KareKodIstasyonId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodIsEmriIstasyonMTMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodMüşteris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToGLN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodMüşteris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KareKodStoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sn = table.Column<long>(type: "bigint", nullable: false),
                    Bn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gtin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Md = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaletSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackSscc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    NotificationStatus = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodStoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramŞirketGrups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ŞirketAktifmi = table.Column<int>(type: "int", nullable: true),
                    YetkiliİletişimNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramŞirketGrups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SıcakSatışButonProfils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SıcakSatışButonProfils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SideBarMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    IconCss = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsParent = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideBarMenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SorumluKullanıcıGrups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SorumluKullanıcıGrups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControllerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrxResult = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IPAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SystemUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Şantiyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Şantiyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    SystemUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementRoles_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementUsers_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SıcakSatışAyars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HızlıButonProfilId = table.Column<int>(type: "int", nullable: true),
                    CariKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermalYazıcıIpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SıcakSatışAyars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SıcakSatışAyars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DosyaİçerikGörmeYetkis",
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
                    table.PrimaryKey("PK_DosyaİçerikGörmeYetkis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosyaİçerikGörmeYetkis_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaİçerikGörmeYetkis_Dosyas_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "DökümanAlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DolduralacakAlanString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanTipi = table.Column<int>(type: "int", nullable: false),
                    DökümanId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DökümanAlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DökümanAlans_Dökümans_DökümanId",
                        column: x => x.DökümanId,
                        principalTable: "Dökümans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kareKodIsEmris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedProduct = table.Column<int>(type: "int", nullable: false),
                    PackCount = table.Column<int>(type: "int", nullable: true),
                    BoxCount = table.Column<int>(type: "int", nullable: false),
                    PaletCount = table.Column<int>(type: "int", nullable: false),
                    ProductPerPack = table.Column<int>(type: "int", nullable: true),
                    ProductPerBox = table.Column<int>(type: "int", nullable: true),
                    BoxPerPalet = table.Column<int>(type: "int", nullable: false),
                    PackPerBox = table.Column<int>(type: "int", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KareKodIsEmriIstasyonMTMId = table.Column<int>(type: "int", nullable: true),
                    KareKodIsEmriIstasyonMTMId1 = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kareKodIsEmris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kareKodIsEmris_KareKodAnaUruns_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "KareKodAnaUruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kareKodIsEmris_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                        column: x => x.KareKodIsEmriIstasyonMTMId1,
                        principalTable: "KareKodIsEmriIstasyonMTMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodIstasyons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstasyonAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    X1JetIpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YazıcıIpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KareKodIsEmriIstasyonMTMId = table.Column<int>(type: "int", nullable: true),
                    KareKodIsEmriIstasyonMTMId1 = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodIstasyons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodIstasyons_KareKodIsEmriIstasyonMTMs_KareKodIsEmriIstasyonMTMId1",
                        column: x => x.KareKodIsEmriIstasyonMTMId1,
                        principalTable: "KareKodIsEmriIstasyonMTMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodBildirimEmris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodBildirimTürüId = table.Column<int>(type: "int", nullable: false),
                    KareKodAnaUrunId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: true),
                    KareKodMüşteriId = table.Column<int>(type: "int", nullable: true),
                    DökümanTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DökümanNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KareKodDeaktivasyonTürüId = table.Column<int>(type: "int", nullable: true),
                    ReceiverDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BildirimDurumu = table.Column<int>(type: "int", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PtsGönderimDurumu = table.Column<int>(type: "int", nullable: true),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiparişNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodBildirimEmris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimEmris_KareKodAnaUruns_KareKodAnaUrunId",
                        column: x => x.KareKodAnaUrunId,
                        principalTable: "KareKodAnaUruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimEmris_KareKodBildirimTürüs_KareKodBildirimTürüId",
                        column: x => x.KareKodBildirimTürüId,
                        principalTable: "KareKodBildirimTürüs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimEmris_KareKodDeaktivasyonTürüs_KareKodDeaktivasyonTürüId",
                        column: x => x.KareKodDeaktivasyonTürüId,
                        principalTable: "KareKodDeaktivasyonTürüs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KareKodBildirimEmris_KareKodMüşteris_KareKodMüşteriId",
                        column: x => x.KareKodMüşteriId,
                        principalTable: "KareKodMüşteris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodMüşteriYetkilileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodMüşteriId = table.Column<int>(type: "int", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodMüşteriYetkilileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodMüşteriYetkilileri_KareKodMüşteris_KareKodMüşteriId",
                        column: x => x.KareKodMüşteriId,
                        principalTable: "KareKodMüşteris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CariKoduTanıms",
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
                    table.PrimaryKey("PK_CariKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Caris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tür = table.Column<int>(type: "int", nullable: false),
                    CariKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caris_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Depos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    DepoAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepoAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepoKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depos_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

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
                    ParentId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "ProgramŞirketKullanıcıs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramŞirketKullanıcıs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramŞirketKullanıcıs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgramŞirketKullanıcıs_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reçetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    ReçeteAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Reçetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçetes_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StokKoduTanıms",
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
                    table.PrimaryKey("PK_StokKoduTanıms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokKoduTanıms_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tezgah",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    TezgahAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tezgah", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tezgah_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SıcakSatışHızlıButons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButonRengi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButonAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RivaStokId = table.Column<int>(type: "int", nullable: true),
                    StokAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sıcakSatışButonProfilId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SıcakSatışHızlıButons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SıcakSatışHızlıButons_SıcakSatışButonProfils_sıcakSatışButonProfilId",
                        column: x => x.sıcakSatışButonProfilId,
                        principalTable: "SıcakSatışButonProfils",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SorumluKullanıcıs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorumluKullanıcıGrupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SorumluKullanıcıs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SorumluKullanıcıs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SorumluKullanıcıs_SorumluKullanıcıGrups_SorumluKullanıcıGrupId",
                        column: x => x.SorumluKullanıcıGrupId,
                        principalTable: "SorumluKullanıcıGrups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DökümanSelectBoxItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DökümanAlanId = table.Column<int>(type: "int", nullable: false),
                    ItemValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DökümanSelectBoxItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DökümanSelectBoxItems_DökümanAlans_DökümanAlanId",
                        column: x => x.DökümanAlanId,
                        principalTable: "DökümanAlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "KareKodUrunlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sn = table.Column<long>(type: "bigint", nullable: false),
                    Bn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gtin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Md = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoorId = table.Column<int>(type: "int", nullable: false),
                    PaletSn = table.Column<int>(type: "int", nullable: false),
                    BoxSn = table.Column<int>(type: "int", nullable: false),
                    PackSn = table.Column<int>(type: "int", nullable: false),
                    PaletSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxSscc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackSscc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodUrunlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodUrunlers_kareKodIsEmris_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "kareKodIsEmris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodBildirimStokMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodBildirimEmriId = table.Column<int>(type: "int", nullable: true),
                    KareKodStokId = table.Column<int>(type: "int", nullable: true),
                    BildirimDurumu = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodBildirimStokMTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimStokMTMs_KareKodBildirimEmris_KareKodBildirimEmriId",
                        column: x => x.KareKodBildirimEmriId,
                        principalTable: "KareKodBildirimEmris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KareKodBildirimStokMTMs_KareKodStoks_KareKodStokId",
                        column: x => x.KareKodStokId,
                        principalTable: "KareKodStoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CariHarekets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketTürü = table.Column<int>(type: "int", nullable: false),
                    ÖdemeTürü = table.Column<int>(type: "int", nullable: false),
                    ÇekNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ÇekGörselUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariHarekets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariHarekets_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    StokAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ÜstStokId = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: true),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    StokKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stoks_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stoks_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stoks_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FaturaBaslıks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    FaturaTürü = table.Column<int>(type: "int", nullable: false),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriNo = table.Column<int>(type: "int", nullable: false),
                    FaturaSeriId = table.Column<int>(type: "int", nullable: false),
                    ÖdemeSeriId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaBaslıks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaBaslıks_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaBaslıks_FaturaSeris_FaturaSeriId",
                        column: x => x.FaturaSeriId,
                        principalTable: "FaturaSeris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaBaslıks_ÖdemeSeris_ÖdemeSeriId",
                        column: x => x.ÖdemeSeriId,
                        principalTable: "ÖdemeSeris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaturaBaslıks_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "İşEmris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    ReçeteId = table.Column<int>(type: "int", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İşEmriAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HedefÜretim = table.Column<int>(type: "int", nullable: false),
                    HedefBaşlamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HedefBitişTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşEmris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İşEmris_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İşEmris_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İşs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    IşAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TezgahId = table.Column<int>(type: "int", nullable: true),
                    İşTamamlanmaSüresi = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İşs_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İşs_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Tezgah_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: true),
                    TezgahId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Tezgah_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Tezgah_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Tezgah_MTM_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KareKodBildirimUruns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KareKodUrunlerId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KareKodBildirimUruns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KareKodBildirimUruns_KareKodUrunlers_KareKodUrunlerId",
                        column: x => x.KareKodUrunlerId,
                        principalTable: "KareKodUrunlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barkods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: false),
                    İçerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barkods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barkods_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barkods_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlokBilgis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    Kalite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kat = table.Column<int>(type: "int", nullable: false),
                    Stun = table.Column<int>(type: "int", nullable: false),
                    Derinlik = table.Column<int>(type: "int", nullable: false),
                    ŞantiyeId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlokBilgis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlokBilgis_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlokBilgis_Şantiyes_ŞantiyeId",
                        column: x => x.ŞantiyeId,
                        principalTable: "Şantiyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fiyats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeçerliFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeçerliKdvOranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiyats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fiyats_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Stok_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    KullanılacakAdet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Stok_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Stok_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reçete_Stok_MTM_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaBaslıkId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KdvOranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaDetay_FaturaBaslıks_FaturaBaslıkId",
                        column: x => x.FaturaBaslıkId,
                        principalTable: "FaturaBaslıks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaDetay_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ödemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    FaturaBaslıkId = table.Column<int>(type: "int", nullable: false),
                    Açıklama = table.Column<int>(type: "int", nullable: false),
                    ÖdemeTürü = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeriNo = table.Column<int>(type: "int", nullable: false),
                    ÖdemeSeriId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ödemes_ÖdemeSeris_ÖdemeSeriId",
                        column: x => x.ÖdemeSeriId,
                        principalTable: "ÖdemeSeris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ödemes_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StokHarekets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    HareketTipi = table.Column<int>(type: "int", nullable: true),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FaturaBaslıkId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHarekets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokHarekets_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokHarekets_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokHarekets_FaturaBaslıks_FaturaBaslıkId",
                        column: x => x.FaturaBaslıkId,
                        principalTable: "FaturaBaslıks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokHarekets_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokHarekets_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Uruns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramŞirketGrupId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İşEmriId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uruns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uruns_İşEmris_İşEmriId",
                        column: x => x.İşEmriId,
                        principalTable: "İşEmris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uruns_ProgramŞirketGrups_ProgramŞirketGrupId",
                        column: x => x.ProgramŞirketGrupId,
                        principalTable: "ProgramŞirketGrups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReçeteId = table.Column<int>(type: "int", nullable: true),
                    IşId = table.Column<int>(type: "int", nullable: true),
                    İşAçıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İşTamamlanmaSüresi = table.Column<int>(type: "int", nullable: true),
                    SorumluKullanıcıGrupId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_İşs_IşId",
                        column: x => x.IşId,
                        principalTable: "İşs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_Reçetes_ReçeteId",
                        column: x => x.ReçeteId,
                        principalTable: "Reçetes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_SorumluKullanıcıGrups_SorumluKullanıcıGrupId",
                        column: x => x.SorumluKullanıcıGrupId,
                        principalTable: "SorumluKullanıcıGrups",
                        principalColumn: "Id");
                });

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
                        name: "FK_Tezgah_Iş_MTMs_İşs_IşId",
                        column: x => x.IşId,
                        principalTable: "İşs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tezgah_Iş_MTMs_Tezgah_TezgahId",
                        column: x => x.TezgahId,
                        principalTable: "Tezgah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlokGörüntüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlokBilgiId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlokGörüntüs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlokGörüntüs_BlokBilgis_BlokBilgiId",
                        column: x => x.BlokBilgiId,
                        principalTable: "BlokBilgis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_UrunAşamalarıs_İşEmris_İşEmriId",
                        column: x => x.İşEmriId,
                        principalTable: "İşEmris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_İşs_IşId",
                        column: x => x.IşId,
                        principalTable: "İşs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunAşamalarıs_Uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Uruns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "İşEmriDurums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İşEmriId = table.Column<int>(type: "int", nullable: true),
                    Reçete_Iş_MTMId = table.Column<int>(type: "int", nullable: true),
                    TamamlanmaDurum = table.Column<int>(type: "int", nullable: true),
                    YapılacakİşId = table.Column<int>(type: "int", nullable: true),
                    BaşlamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitişTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşEmriDurums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İşEmriDurums_İşEmris_İşEmriId",
                        column: x => x.İşEmriId,
                        principalTable: "İşEmris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İşEmriDurums_İşs_YapılacakİşId",
                        column: x => x.YapılacakİşId,
                        principalTable: "İşs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İşEmriDurums_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                        column: x => x.Reçete_Iş_MTMId,
                        principalTable: "Reçete_Iş_MTM",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM_KullanılacakStoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reçete_Iş_MTMId = table.Column<int>(type: "int", nullable: true),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    KullanılacakStokMiktarı = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM_KullanılacakStoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                        column: x => x.Reçete_Iş_MTMId,
                        principalTable: "Reçete_Iş_MTM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_KullanılacakStoks_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reçete_Iş_MTM_ÜretilecekStoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reçete_Iş_MTMId = table.Column<int>(type: "int", nullable: true),
                    DepoId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    ÜretilecekStokMiktarı = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reçete_Iş_MTM_ÜretilecekStoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTM_Reçete_Iş_MTMId",
                        column: x => x.Reçete_Iş_MTMId,
                        principalTable: "Reçete_Iş_MTM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reçete_Iş_MTM_ÜretilecekStoks_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Birims",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "BirimKodu", "DönüşümAçıklama", "DönüşümKodu", "IsDeleted", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ADET", "ADET", "NIU", false, true, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "KG", "KİLOGRAM", "KGM", false, true, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GR", "GRAM", "GRM", false, true, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M", "METRE", "MTR", false, true, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LİTRE", "LİTRE", "LTR", false, true, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PA", "PAKET (Packet)", "PA", false, true, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PK", "PAKET (Pack)", "PK", false, true, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "KUTU", "KUTU", "BX", false, true, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "METRE", "METRE", "MTR", false, true, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CM", "SANTİMETRE", "CMT", false, true, null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M3", "METREKÜB", "MTQ", false, true, null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "M2", "METREKARE", "MTK", false, true, null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RULO", "RULO", "ROLL", false, true, null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SET", "SET", "SET", false, true, null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CM3", "SANTİMETREKÜB", "CMQ", false, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Afghanistan", 1, "AF", true, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Albania", 2, "AL", true, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Algeria", 3, "DZ", true, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "American Samoa", 4, "AS", true, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Andorra", 5, "AD", true, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Angola", 6, "AO", true, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Anguilla", 7, "AI", true, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Antarctica", 8, "AQ", true, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Antigua and Barbuda", 9, "AG", true, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Argentina", 10, "AR", true, null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Armenia", 11, "AM", true, null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aruba", 12, "AW", true, null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Australia", 13, "AU", true, null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Austria", 14, "AT", true, null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Azerbaijan", 15, "AZ", true, null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bahamas (the)", 16, "BS", true, null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bahrain", 17, "BH", true, null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bangladesh", 18, "BD", true, null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Barbados", 19, "BB", true, null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Belarus", 20, "BY", true, null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Belgium", 21, "BE", true, null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Belize", 22, "BZ", true, null, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Benin", 23, "BJ", true, null, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bermuda", 24, "BM", true, null, null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bhutan", 25, "BT", true, null, null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bolivia (Plurinational State of)", 26, "BO", true, null, null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bonaire, Sint Eustatius and Saba", 27, "BQ", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bosnia and Herzegovina", 28, "BA", true, null, null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Botswana", 29, "BW", true, null, null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bouvet Island", 30, "BV", true, null, null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Brazil", 31, "BR", true, null, null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "British Indian Ocean Territory (the)", 32, "IO", true, null, null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Brunei Darussalam", 33, "BN", true, null, null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Bulgaria", 34, "BG", true, null, null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Burkina Faso", 35, "BF", true, null, null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Burundi", 36, "BI", true, null, null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cabo Verde", 37, "CV", true, null, null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cambodia", 38, "KH", true, null, null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cameroon", 39, "CM", true, null, null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Canada", 40, "CA", true, null, null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cayman Islands (the)", 41, "KY", true, null, null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Central African Republic (the)", 42, "CF", true, null, null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Chad", 43, "TD", true, null, null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Chile", 44, "CL", true, null, null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "China", 45, "CN", true, null, null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Christmas Island", 46, "CX", true, null, null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cocos (Keeling) Islands (the)", 47, "CC", true, null, null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Colombia", 48, "CO", true, null, null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Comoros (the)", 49, "KM", true, null, null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Congo (the Democratic Republic of the)", 50, "CD", true, null, null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Congo (the)", 51, "CG", true, null, null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cook Islands (the)", 52, "CK", true, null, null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Costa Rica", 53, "CR", true, null, null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Croatia", 54, "HR", true, null, null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cuba", 55, "CU", true, null, null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Curaçao", 56, "CW", true, null, null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cyprus", 57, "CY", true, null, null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Czechia", 58, "CZ", true, null, null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Côte dIvoire", 59, "CI", true, null, null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Denmark", 60, "DK", true, null, null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Djibouti", 61, "DJ", true, null, null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Dominica", 62, "DM", true, null, null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Dominican Republic (the)", 63, "DO", true, null, null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Ecuador", 64, "EC", true, null, null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Egypt", 65, "EG", true, null, null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "El Salvador", 66, "SV", true, null, null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Equatorial Guinea", 67, "GQ", true, null, null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Eritrea", 68, "ER", true, null, null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Estonia", 69, "EE", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Eswatini", 70, "SZ", true, null, null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Ethiopia", 71, "ET", true, null, null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Falkland Islands (the) [Malvinas]", 72, "FK", true, null, null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Faroe Islands (the)", 73, "FO", true, null, null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Fiji", 74, "FJ", true, null, null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Finland", 75, "FI", true, null, null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "France", 76, "FR", true, null, null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "French Guiana", 77, "GF", true, null, null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "French Polynesia", 78, "PF", true, null, null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "French Southern Territories (the)", 79, "TF", true, null, null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Gabon", 80, "GA", true, null, null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Gambia (the)", 81, "GM", true, null, null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Georgia", 82, "GE", true, null, null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Germany", 83, "DE", true, null, null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Ghana", 84, "GH", true, null, null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Gibraltar", 85, "GI", true, null, null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Greece", 86, "GR", true, null, null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Greenland", 87, "GL", true, null, null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Grenada", 88, "GD", true, null, null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guadeloupe", 89, "GP", true, null, null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guam", 90, "GU", true, null, null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guatemala", 91, "GT", true, null, null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guernsey", 92, "GG", true, null, null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guinea", 93, "GN", true, null, null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guinea-Bissau", 94, "GW", true, null, null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Guyana", 95, "GY", true, null, null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Haiti", 96, "HT", true, null, null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Heard Island and McDonald Islands", 97, "HM", true, null, null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Holy See (the)", 98, "VA", true, null, null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Honduras", 99, "HN", true, null, null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Hong Kong", 100, "HK", true, null, null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Hungary", 101, "HU", true, null, null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Jamaica", 102, "JM", true, null, null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Japan", 103, "JP", true, null, null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Jersey", 104, "JE", true, null, null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Jordan", 105, "JO", true, null, null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Kazakhstan", 106, "KZ", true, null, null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Kenya", 107, "KE", true, null, null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Kiribati", 108, "KI", true, null, null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Korea (the Democratic Peoples Republic of)", 109, "KP", true, null, null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Korea (the Republic of)", 110, "KR", true, null, null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Kuwait", 111, "KW", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Kyrgyzstan", 112, "KG", true, null, null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Lao Peoples Democratic Republic(the)", 113, "LA", true, null, null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Latvia", 114, "LV", true, null, null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Lebanon", 115, "LB", true, null, null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Lesotho", 116, "LS", true, null, null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Liberia", 117, "LR", true, null, null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Libya", 118, "LY", true, null, null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Liechtenstein", 119, "LI", true, null, null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Lithuania", 120, "LT", true, null, null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Luxembourg", 121, "LU", true, null, null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Macao", 122, "MO", true, null, null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Madagascar", 123, "MG", true, null, null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Malawi", 124, "MW", true, null, null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Malaysia", 125, "MY", true, null, null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Maldives", 126, "MV", true, null, null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mali", 127, "ML", true, null, null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Malta", 128, "MT", true, null, null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Marshall Islands (the)", 129, "MH", true, null, null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Martinique", 130, "MQ", true, null, null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mauritania", 131, "MR", true, null, null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mauritius", 132, "MU", true, null, null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mayotte", 133, "YT", true, null, null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mexico", 134, "MX", true, null, null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Micronesia (Federated States of)", 135, "FM", true, null, null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Moldova (the Republic of)", 136, "MD", true, null, null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Monaco", 137, "MC", true, null, null },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mongolia", 138, "MN", true, null, null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Montenegro", 139, "ME", true, null, null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Montserrat", 140, "MS", true, null, null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Morocco", 141, "MA", true, null, null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Mozambique", 142, "MZ", true, null, null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Myanmar", 143, "MM", true, null, null },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Namibia", 144, "NA", true, null, null },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Nauru", 145, "NR", true, null, null },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Nepal", 146, "NP", true, null, null },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Netherlands (the)", 147, "NL", true, null, null },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "New Caledonia", 148, "NC", true, null, null },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "New Zealand", 149, "NZ", true, null, null },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Nicaragua", 150, "NI", true, null, null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Niger (the)", 151, "NE", true, null, null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Nigeria", 152, "NG", true, null, null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Niue", 153, "NU", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Norfolk Island", 154, "NF", true, null, null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Northern Mariana Islands (the)", 155, "MP", true, null, null },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Norway", 156, "NO", true, null, null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Oman", 157, "OM", true, null, null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Pakistan", 158, "PK", true, null, null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Palau", 159, "PW", true, null, null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Palestine, State of", 160, "PS", true, null, null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Panama", 161, "PA", true, null, null },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Papua New Guinea", 162, "PG", true, null, null },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Paraguay", 163, "PY", true, null, null },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Peru", 164, "PE", true, null, null },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Philippines (the)", 165, "PH", true, null, null },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Pitcairn", 166, "PN", true, null, null },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Poland", 167, "PL", true, null, null },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Portugal", 168, "PT", true, null, null },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Puerto Rico", 169, "PR", true, null, null },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Qatar", 170, "QA", true, null, null },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Republic of North Macedonia", 171, "MK", true, null, null },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Romania", 172, "RO", true, null, null },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Russian Federation (the)", 173, "RU", true, null, null },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Rwanda", 174, "RW", true, null, null },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Réunion", 175, "RE", true, null, null },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Barthélemy", 176, "BL", true, null, null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Helena, Ascension and Tristan da Cunha", 177, "SH", true, null, null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Kitts and Nevis", 178, "KN", true, null, null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Lucia", 179, "LC", true, null, null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Martin (French part)", 180, "MF", true, null, null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Pierre and Miquelon", 181, "PM", true, null, null },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saint Vincent and the Grenadines", 182, "VC", true, null, null },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Samoa", 183, "WS", true, null, null },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "San Marino", 184, "SM", true, null, null },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sao Tome and Principe", 185, "ST", true, null, null },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Saudi Arabia", 186, "SA", true, null, null },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Senegal", 187, "SN", true, null, null },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Serbia", 188, "RS", true, null, null },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Seychelles", 189, "SC", true, null, null },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sierra Leone", 190, "SL", true, null, null },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Singapore", 191, "SG", true, null, null },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sint Maarten (Dutch part)", 192, "SX", true, null, null },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Slovakia", 193, "SK", true, null, null },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Slovenia", 194, "SI", true, null, null },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Solomon Islands", 195, "SB", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Somalia", 196, "SO", true, null, null },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "South Africa", 197, "ZA", true, null, null },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "South Georgia and the South Sandwich Islands", 198, "GS", true, null, null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "South Sudan", 199, "SS", true, null, null },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Spain", 200, "ES", true, null, null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sri Lanka", 201, "LK", true, null, null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sudan (the)", 202, "SD", true, null, null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Suriname", 203, "SR", true, null, null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Svalbard and Jan Mayen", 204, "SJ", true, null, null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Sweden", 205, "SE", true, null, null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Switzerland", 206, "CH", true, null, null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Syrian Arab Republic", 207, "SY", true, null, null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Taiwan (Province of China)", 208, "TW", true, null, null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tajikistan", 209, "TJ", true, null, null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tanzania, United Republic of", 210, "TZ", true, null, null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Thailand", 211, "TH", true, null, null },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Timor-Leste", 212, "TL", true, null, null },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Togo", 213, "TG", true, null, null },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tokelau", 214, "TK", true, null, null },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tonga", 215, "TO", true, null, null },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Trinidad and Tobago", 216, "TT", true, null, null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tunisia", 217, "TN", true, null, null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Turkey", 218, "TR", true, null, null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Turkmenistan", 219, "TM", true, null, null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Turks and Caicos Islands (the)", 220, "TC", true, null, null },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Tuvalu", 221, "TV", true, null, null },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Uganda", 222, "UG", true, null, null },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Ukraine", 223, "UA", true, null, null },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "United Arab Emirates (the)", 224, "AE", true, null, null },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "United Kingdom of Great Britain and Northern Ireland (the)", 225, "GB", true, null, null },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "United States Minor Outlying Islands (the)", 226, "UM", true, null, null },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "United States of America (the)", 227, "US", true, null, null },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Uruguay", 228, "UY", true, null, null },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Uzbekistan", 229, "UZ", true, null, null },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Vanuatu", 230, "VU", true, null, null },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Venezuela (Bolivarian Republic of)", 231, "VE", true, null, null },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Viet Nam", 232, "VN", true, null, null },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Virgin Islands (British)", 233, "VG", true, null, null },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Virgin Islands (U.S.)", 234, "VI", true, null, null },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Wallis and Futuna", 235, "WF", true, null, null },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Western Sahara", 236, "EH", true, null, null },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Yemen", 237, "YE", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IsDeleted", "Name", "Row", "ShortName", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Zambia", 238, "ZM", true, null, null },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Zimbabwe", 239, "ZW", true, null, null },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Åland Islands", 240, "AX", true, null, null },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Iceland", 241, "IS", true, null, null },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "India", 242, "IN", true, null, null },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Indonesia", 243, "ID", true, null, null },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Iran (Islamic Republic of)", 244, "IR", true, null, null },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Iraq", 245, "IQ", true, null, null },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Ireland", 246, "IE", true, null, null },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Isle of Man", 247, "IM", true, null, null },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Israel", 248, "IL", true, null, null },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Italy", 249, "IT", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "KareKodBildirimTürüs",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "BildirimTürü", "BildirimTürüKodu", "IsDeleted", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Üretim", "M", false, true, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Satış", "S", false, true, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Satış Iptal", "C", false, true, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ihracat", "X", false, true, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ithalat", "I", false, true, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Deaktivasyon", "D", false, true, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mal Alım", "A", false, true, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mal Iade", "F", false, true, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mal Devir", "S", false, true, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mal Devir Iptal", "C", false, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "KareKodDeaktivasyonTürüs",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "DeaktivasyonKodu", "IsDeleted", "Sebep", "Status", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "10", false, "SİSTEMDEN ÇIKARMA", true, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "20", false, "ÜRETİM FİRELERİ", true, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "30", false, "GERİ ÇEKME SEBEBİYLE İMHA", true, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "40", false, "MİAT SEBEBİYLE İMHA", true, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", false, "REVİZYON", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-gear", false, false, true, "Ayarlar", null, null, 1999, true, null, null, "#" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Menü Ayarları", null, 1, 1999, true, null, null, "/Setting/MenuList" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Log Arama", null, 1, 299, true, null, null, "/Setting/SystemUserLogListSearch" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Ulke Ayarları", null, 1, 39999, true, null, null, "/Setting/CountryList" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-address-card", false, false, true, "Role İşlemleri", null, null, 2999, true, null, null, "#" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Rol Listesi", null, 5, 199999, true, null, null, "/Role/RoleList" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Rol Ekle", null, 5, 299999, true, null, null, "/Role/CreateRole" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Kullanıcı İşlemleri", null, null, 3999, true, null, null, "#" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Arama", null, 8, 1999, true, null, null, "/User/Search" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Kullanıcı Ekle", null, 8, 299, true, null, null, "/User/AddUser" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-chalkboard-user", false, false, true, "Diğer İşlemler", null, null, 9999, true, null, null, "#" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Bize Yazanlar", null, 28, 10999, true, null, null, "/SystemAdmin/ContactList" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-address-card", false, false, false, "Hesabım", null, null, 11, true, null, null, "/Account/accountinformation" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-right-from-bracket", false, false, false, "Çıkış Yap", null, null, 12, true, null, null, "/Account/Logout" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-right-from-bracket", false, false, true, "Announcement", null, null, 12, true, null, null, "#" }
                });

            migrationBuilder.InsertData(
                table: "SideBarMenuItems",
                columns: new[] { "Id", "AddedDate", "AddedUserId", "IconCss", "IsDeleted", "IsOpen", "IsParent", "Name", "Order", "ParentId", "Row", "Status", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[,]
                {
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Depo", null, null, 12, true, null, null, "/Depo/Index" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Cariler", null, null, 3, true, null, null, "#" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Müşteriler", null, 43, 1, true, null, null, "/Cari/Müşteriler" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Tedarikçiler", null, 43, 2, true, null, null, "/Cari/Tedarikçiler" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Şantiye", null, null, 3, true, null, null, "#" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Şantiyeler", null, 46, 1, true, null, null, "/Şantiye/Index" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Stok", null, null, 3, true, null, null, "#" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Stok", null, 48, 1, true, null, null, "/Stok/Index" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Hızlı Stok Kartı Oluştur", null, 48, 1, true, null, null, "/Stok/HızlıStokKartıOluştur" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "DosyaYönetimi", null, null, 12, true, null, null, "/DosyaYönetimi/Index" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "KareKod", null, null, 3, true, null, null, "#" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "İş Emirleri", null, 52, 1, true, null, null, "/Karekod/Index" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Bildirim Emirleri", null, 52, 1, true, null, null, "/KareKod/BildirimEmirleri" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Tanımlar", null, null, 3, true, null, null, "#" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Stok Kodu Tanımı", null, 55, 1, true, null, null, "/Tanımlar/StokKoduTanım" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Cari Kodu Tanımı", null, 55, 1, true, null, null, "/Tanımlar/CariKoduTanım" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Cariler", null, 43, 1, true, null, null, "/Cari/Cariler" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Yönetim", null, null, 3, true, null, null, "#" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Program", null, 59, 1, true, null, null, "/Program/Index" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Üretim", null, null, 3, true, null, null, "#" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Reçete", null, 61, 2, true, null, null, "/Reçete/Index" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Tezgah", null, 61, 3, true, null, null, "/Tezgah/Index" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Iş", null, 61, 4, true, null, null, "/Iş/Index" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-receipt", false, false, false, "Iş Emri", null, 61, 1, true, null, null, "/IşEmri/Index" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Belge Tasarımı", null, null, 3, true, null, null, "#" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Tasarlanmış Belgeler", null, 66, 1, true, null, null, "/BelgeTasarım/Belgeler" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Ana Urunler", null, 52, 1, true, null, null, "/KareKod/AnaUrunler" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Fabrika Makina Yönetimi", null, null, 3, true, null, null, "#" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "İlaç Fırın", null, 69, 1, true, null, null, "/FabrikaMakinaYönetimi/Fırın" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "İstasyonlar", null, 52, 1, true, null, null, "/KareKod/Istasyon" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Döküman Yönetimi", null, null, 3, true, null, null, "#" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Dökümanlar", null, 73, 1, true, null, null, "/Döküman/Index" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Aktarım", null, 52, 1, true, null, null, "/KareKod/Aktarım" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Müşteriler", null, 52, 1, true, null, null, "/KareKod/Müşteriler" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Depo Kodu Tanımı", null, 55, 1, true, null, null, "/Tanımlar/DepoKoduTanım" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Kasa Kodu Tanımı", null, 55, 1, true, null, null, "/Tanımlar/KasaKoduTanım" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Seri No Tanımları", null, null, 3, true, null, null, "#" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Fatura Seri No Tanımı", null, 82, 1, true, null, null, "/SeriNo/FaturaSeriNoTanım" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Ödeme Seri No Tanımı", null, 82, 1, true, null, null, "/SeriNo/ÖdemeSeriNoTanım" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon fa-solid fa-user-group", false, false, true, "Kasa", null, null, 3, true, null, null, "#" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Kasa", null, 85, 1, true, null, null, "/Kasa/Index" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nav-icon far fa-circle text-info", false, false, false, "Sorumlu Kullanıcılar", null, 61, 3, true, null, null, "/SorumluKullanıcı/Index" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementRoles_AnnouncementId",
                table: "AnnouncementRoles",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Barkods_ProgramŞirketGrupId",
                table: "Barkods",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Barkods_StokId",
                table: "Barkods",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_BlokBilgis_StokId",
                table: "BlokBilgis",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_BlokBilgis_ŞantiyeId",
                table: "BlokBilgis",
                column: "ŞantiyeId");

            migrationBuilder.CreateIndex(
                name: "IX_BlokGörüntüs_BlokBilgiId",
                table: "BlokGörüntüs",
                column: "BlokBilgiId");

            migrationBuilder.CreateIndex(
                name: "IX_CariHarekets_CariId",
                table: "CariHarekets",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariKoduTanıms_ProgramŞirketGrupId",
                table: "CariKoduTanıms",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_ProgramŞirketGrupId",
                table: "Caris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_DepoKoduTanıms_ProgramŞirketGrupId",
                table: "DepoKoduTanıms",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Depos_ProgramŞirketGrupId",
                table: "Depos",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİçerikGörmeYetkis_DosyaId",
                table: "DosyaİçerikGörmeYetkis",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_DosyaİçerikGörmeYetkis_UserId",
                table: "DosyaİçerikGörmeYetkis",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_DökümanAlans_DökümanId",
                table: "DökümanAlans",
                column: "DökümanId");

            migrationBuilder.CreateIndex(
                name: "IX_DökümanSelectBoxItems_DökümanAlanId",
                table: "DökümanSelectBoxItems",
                column: "DökümanAlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_CariId",
                table: "FaturaBaslıks",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_FaturaSeriId",
                table: "FaturaBaslıks",
                column: "FaturaSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_ÖdemeSeriId",
                table: "FaturaBaslıks",
                column: "ÖdemeSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaBaslıks_ProgramŞirketGrupId",
                table: "FaturaBaslıks",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_FaturaBaslıkId",
                table: "FaturaDetay",
                column: "FaturaBaslıkId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_StokId",
                table: "FaturaDetay",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaSeris_ProgramŞirketGrupId",
                table: "FaturaSeris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Fiyats_StokId",
                table: "Fiyats",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_İşEmriId",
                table: "İşEmriDurums",
                column: "İşEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_Reçete_Iş_MTMId",
                table: "İşEmriDurums",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmriDurums_YapılacakİşId",
                table: "İşEmriDurums",
                column: "YapılacakİşId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmris_ProgramŞirketGrupId",
                table: "İşEmris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_İşEmris_ReçeteId",
                table: "İşEmris",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_İşs_ProgramŞirketGrupId",
                table: "İşs",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_İşs_TezgahId",
                table: "İşs",
                column: "TezgahId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimEmris_KareKodAnaUrunId",
                table: "KareKodBildirimEmris",
                column: "KareKodAnaUrunId");

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
                name: "IX_KareKodBildirimStokMTMs_KareKodBildirimEmriId",
                table: "KareKodBildirimStokMTMs",
                column: "KareKodBildirimEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimStokMTMs_KareKodStokId",
                table: "KareKodBildirimStokMTMs",
                column: "KareKodStokId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodBildirimUruns_KareKodUrunlerId",
                table: "KareKodBildirimUruns",
                column: "KareKodUrunlerId");

            migrationBuilder.CreateIndex(
                name: "IX_kareKodIsEmris_BaseProductId",
                table: "kareKodIsEmris",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_kareKodIsEmris_KareKodIsEmriIstasyonMTMId1",
                table: "kareKodIsEmris",
                column: "KareKodIsEmriIstasyonMTMId1");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodIstasyons_KareKodIsEmriIstasyonMTMId1",
                table: "KareKodIstasyons",
                column: "KareKodIsEmriIstasyonMTMId1");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodKolis_KareKodIsEmriId",
                table: "KareKodKolis",
                column: "KareKodIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodMüşteriYetkilileri_KareKodMüşteriId",
                table: "KareKodMüşteriYetkilileri",
                column: "KareKodMüşteriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodPalets_KareKodIsEmriId",
                table: "KareKodPalets",
                column: "KareKodIsEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_KareKodUrunlers_WorkOrderId",
                table: "KareKodUrunlers",
                column: "WorkOrderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ödemes_ÖdemeSeriId",
                table: "Ödemes",
                column: "ÖdemeSeriId");

            migrationBuilder.CreateIndex(
                name: "IX_Ödemes_ProgramŞirketGrupId",
                table: "Ödemes",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_ÖdemeSeris_ProgramŞirketGrupId",
                table: "ÖdemeSeris",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramŞirketKullanıcıs_ProgramŞirketGrupId",
                table: "ProgramŞirketKullanıcıs",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramŞirketKullanıcıs_UserId",
                table: "ProgramŞirketKullanıcıs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_IşId",
                table: "Reçete_Iş_MTM",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ReçeteId",
                table: "Reçete_Iş_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_SorumluKullanıcıGrupId",
                table: "Reçete_Iş_MTM",
                column: "SorumluKullanıcıGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_DepoId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_KullanılacakStoks_StokId",
                table: "Reçete_Iş_MTM_KullanılacakStoks",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_DepoId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_Reçete_Iş_MTMId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "Reçete_Iş_MTMId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Iş_MTM_ÜretilecekStoks_StokId",
                table: "Reçete_Iş_MTM_ÜretilecekStoks",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Stok_MTM_ReçeteId",
                table: "Reçete_Stok_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Stok_MTM_StokId",
                table: "Reçete_Stok_MTM",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Tezgah_MTM_ReçeteId",
                table: "Reçete_Tezgah_MTM",
                column: "ReçeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçete_Tezgah_MTM_TezgahId",
                table: "Reçete_Tezgah_MTM",
                column: "TezgahId");

            migrationBuilder.CreateIndex(
                name: "IX_Reçetes_ProgramŞirketGrupId",
                table: "Reçetes",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_SıcakSatışAyars_UserId",
                table: "SıcakSatışAyars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SıcakSatışHızlıButons_sıcakSatışButonProfilId",
                table: "SıcakSatışHızlıButons",
                column: "sıcakSatışButonProfilId");

            migrationBuilder.CreateIndex(
                name: "IX_SorumluKullanıcıs_SorumluKullanıcıGrupId",
                table: "SorumluKullanıcıs",
                column: "SorumluKullanıcıGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_SorumluKullanıcıs_UserId",
                table: "SorumluKullanıcıs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_CariId",
                table: "StokHarekets",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_DepoId",
                table: "StokHarekets",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_FaturaBaslıkId",
                table: "StokHarekets",
                column: "FaturaBaslıkId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_ProgramŞirketGrupId",
                table: "StokHarekets",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHarekets_StokId",
                table: "StokHarekets",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_StokKoduTanıms_ProgramŞirketGrupId",
                table: "StokKoduTanıms",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_BirimId",
                table: "Stoks",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_DepoId",
                table: "Stoks",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_ProgramŞirketGrupId",
                table: "Stoks",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tezgah_ProgramŞirketGrupId",
                table: "Tezgah",
                column: "ProgramŞirketGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tezgah_Iş_MTMs_IşId",
                table: "Tezgah_Iş_MTMs",
                column: "IşId");

            migrationBuilder.CreateIndex(
                name: "IX_Tezgah_Iş_MTMs_TezgahId",
                table: "Tezgah_Iş_MTMs",
                column: "TezgahId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_İşEmriId",
                table: "Uruns",
                column: "İşEmriId");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_ProgramŞirketGrupId",
                table: "Uruns",
                column: "ProgramŞirketGrupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementRoles");

            migrationBuilder.DropTable(
                name: "AnnouncementUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Barkods");

            migrationBuilder.DropTable(
                name: "BlokGörüntüs");

            migrationBuilder.DropTable(
                name: "CariHarekets");

            migrationBuilder.DropTable(
                name: "CariKoduTanıms");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DepoKoduTanıms");

            migrationBuilder.DropTable(
                name: "DosyaİçerikGörmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaİndirmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaİsimDeğiştirmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaSilmeYetkis");

            migrationBuilder.DropTable(
                name: "DosyaYetkiYetkis");

            migrationBuilder.DropTable(
                name: "DökümanSelectBoxItems");

            migrationBuilder.DropTable(
                name: "ExportedFiles");

            migrationBuilder.DropTable(
                name: "FaturaDetay");

            migrationBuilder.DropTable(
                name: "Fiyats");

            migrationBuilder.DropTable(
                name: "İşEmriDurums");

            migrationBuilder.DropTable(
                name: "KareKodBildirimStokMTMs");

            migrationBuilder.DropTable(
                name: "KareKodBildirimUruns");

            migrationBuilder.DropTable(
                name: "KareKodIstasyons");

            migrationBuilder.DropTable(
                name: "KareKodKolis");

            migrationBuilder.DropTable(
                name: "KareKodMüşteriYetkilileri");

            migrationBuilder.DropTable(
                name: "KareKodPalets");

            migrationBuilder.DropTable(
                name: "Kasa");

            migrationBuilder.DropTable(
                name: "KasaKoduTanıms");

            migrationBuilder.DropTable(
                name: "Ödemes");

            migrationBuilder.DropTable(
                name: "ProgramŞirketKullanıcıs");

            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM_KullanılacakStoks");

            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM_ÜretilecekStoks");

            migrationBuilder.DropTable(
                name: "Reçete_Stok_MTM");

            migrationBuilder.DropTable(
                name: "Reçete_Tezgah_MTM");

            migrationBuilder.DropTable(
                name: "SıcakSatışAyars");

            migrationBuilder.DropTable(
                name: "SıcakSatışHızlıButons");

            migrationBuilder.DropTable(
                name: "SideBarMenuItems");

            migrationBuilder.DropTable(
                name: "SorumluKullanıcıs");

            migrationBuilder.DropTable(
                name: "StokHarekets");

            migrationBuilder.DropTable(
                name: "StokKoduTanıms");

            migrationBuilder.DropTable(
                name: "SystemUserLogs");

            migrationBuilder.DropTable(
                name: "Tezgah_Iş_MTMs");

            migrationBuilder.DropTable(
                name: "UrunAşamalarıs");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlokBilgis");

            migrationBuilder.DropTable(
                name: "Dosyas");

            migrationBuilder.DropTable(
                name: "DökümanAlans");

            migrationBuilder.DropTable(
                name: "KareKodBildirimEmris");

            migrationBuilder.DropTable(
                name: "KareKodStoks");

            migrationBuilder.DropTable(
                name: "KareKodUrunlers");

            migrationBuilder.DropTable(
                name: "Reçete_Iş_MTM");

            migrationBuilder.DropTable(
                name: "SıcakSatışButonProfils");

            migrationBuilder.DropTable(
                name: "FaturaBaslıks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Uruns");

            migrationBuilder.DropTable(
                name: "Stoks");

            migrationBuilder.DropTable(
                name: "Şantiyes");

            migrationBuilder.DropTable(
                name: "Dökümans");

            migrationBuilder.DropTable(
                name: "KareKodBildirimTürüs");

            migrationBuilder.DropTable(
                name: "KareKodDeaktivasyonTürüs");

            migrationBuilder.DropTable(
                name: "KareKodMüşteris");

            migrationBuilder.DropTable(
                name: "kareKodIsEmris");

            migrationBuilder.DropTable(
                name: "İşs");

            migrationBuilder.DropTable(
                name: "SorumluKullanıcıGrups");

            migrationBuilder.DropTable(
                name: "Caris");

            migrationBuilder.DropTable(
                name: "FaturaSeris");

            migrationBuilder.DropTable(
                name: "ÖdemeSeris");

            migrationBuilder.DropTable(
                name: "İşEmris");

            migrationBuilder.DropTable(
                name: "Birims");

            migrationBuilder.DropTable(
                name: "Depos");

            migrationBuilder.DropTable(
                name: "KareKodAnaUruns");

            migrationBuilder.DropTable(
                name: "KareKodIsEmriIstasyonMTMs");

            migrationBuilder.DropTable(
                name: "Tezgah");

            migrationBuilder.DropTable(
                name: "Reçetes");

            migrationBuilder.DropTable(
                name: "ProgramŞirketGrups");
        }
    }
}
