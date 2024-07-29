using DataAccess.Concrete.Seeds;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework.DbContexts
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, IdentityRole, string>
    {
        public AppIdentityDbContext()
        {

        }


        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigSettings.ConfigSettingss());
        }

        public static class ConfigSettings
        {
            public static string ConfigSettingss()
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                using (StreamReader file = File.OpenText(path))
                {
                    JObject o = JObject.Parse(file.ReadToEnd());
                    return (string)o["ConnectionStrings"]["AppIdentityDbContextConnection"];
                }
                return null;
            }
        }
        public DbSet<SideBarMenuItem> SideBarMenuItems { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SystemUserLog> SystemUserLogs { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementRole> AnnouncementRoles { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<ExportedFile> ExportedFiles { get; set; }



        public DbSet<Reçete> Reçetes { get; set; }
        public DbSet<Tezgah> Tezgah { get; set; }
        public DbSet<Iş> Işs { get; set; }
        public DbSet<İşEmri> İşEmris { get; set; }
        public DbSet<Reçete_Iş_MTM> Reçete_Iş_MTM { get; set; }
        public DbSet<Reçete_Tezgah_MTM> Reçete_Tezgah_MTM { get; set; }
        public DbSet<Reçete_Stok_MTM> Reçete_Stok_MTM { get; set; }



        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunAşamaları> UrunAşamalarıs { get; set; }
        public DbSet<Tezgah_Iş_MTM> Tezgah_Iş_MTMs { get; set; }
        public DbSet<Depo> Depos { get; set; }
        public DbSet<StokHareket> StokHarekets { get; set; }

        //Urun
        //UrunAşamaları

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MenuItemSeed();
            modelBuilder.CountriesSeed();
            modelBuilder.BirimiSeeds();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
