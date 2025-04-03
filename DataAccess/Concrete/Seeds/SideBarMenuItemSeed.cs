using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Seeds
{
    public static class SideBarMenuItemSeed
    {
        public static void MenuItemSeed(this ModelBuilder modelBuilder)
        {

            var sideBarMenuItems = new List<SideBarMenuItem>
            {
                //Ayarlar
                new SideBarMenuItem{Id=1,Name="Ayarlar",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-gear",Url = "#",Row=1999},
                new SideBarMenuItem{Id=2,Name="Menü Ayarları",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/MenuList",Row=1999},
                new SideBarMenuItem{Id=3,Name="Log Arama",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/SystemUserLogListSearch",Row=299},
                new SideBarMenuItem{Id=4,Name="Ulke Ayarları",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/CountryList",Row=39999},

                //Role Ayarları
                new SideBarMenuItem{Id=5,Name="Role İşlemleri",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-address-card",Url = "#",Row=2999},
                new SideBarMenuItem{Id=6,Name="Rol Listesi",IsParent=false,ParentId=5,IconCss = "nav-icon far fa-circle text-info",Url = "/Role/RoleList",Row=199999},
                new SideBarMenuItem{Id=7,Name="Rol Ekle",IsParent=false,ParentId=5,IconCss = "nav-icon far fa-circle text-info",Url = "/Role/CreateRole",Row=299999},

                //Kullanıcı İşlemleri 
                new SideBarMenuItem{Id=8,Name="Kullanıcı İşlemleri",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3999},
                new SideBarMenuItem{Id=9,Name="Arama",IsParent=false,ParentId=8,IconCss = "nav-icon far fa-circle text-info",Url = "/User/Search",Row=1999},
                new SideBarMenuItem{Id=10,Name="Kullanıcı Ekle",IsParent=false,ParentId=8,IconCss = "nav-icon far fa-circle text-info",Url = "/User/AddUser",Row=299},

         

                //Diğer İşlemler  
                new SideBarMenuItem{Id=28,Name="Diğer İşlemler",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-chalkboard-user",Url = "#",Row=9999},
                new SideBarMenuItem{Id=29,Name="Bize Yazanlar",IsParent=false,ParentId=28,IconCss = "nav-icon far fa-circle text-info",Url = "/SystemAdmin/ContactList",Row=10999},

                //Hesabım
                new SideBarMenuItem{Id=30,Name="Hesabım",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-address-card",Url = "/Account/accountinformation",Row=11},
               
                //Çıkış Yap
                new SideBarMenuItem{Id=31,Name="Çıkış Yap",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Account/Logout",Row=12},


                //new SideBarMenuItem{Id=32,Name="Transactions",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "#",Row=12},
                //new SideBarMenuItem{Id=33,Name="Transactions",IsParent=false,ParentId=32,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Transaction/AllTransactions",Row=12},

                new SideBarMenuItem{Id=34,Name="Announcement",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "#",Row=12},
                new SideBarMenuItem{Id=35,Name="Announcement List",IsParent=false,ParentId=34,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Announcement/AnnouncementList",Row=12},


                new SideBarMenuItem{Id=61,Name="Üretim",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=62,Name="Reçete",IsParent=false,ParentId=61,IconCss = "nav-icon far fa-circle text-info",Url = "/Reçete/Index",Row=2},
                new SideBarMenuItem{Id=63,Name="Tezgah",IsParent=false,ParentId=61,IconCss = "nav-icon far fa-circle text-info",Url = "/Tezgah/Index",Row=3},
                new SideBarMenuItem{Id=88,Name="Sorumlu Kullanıcılar",IsParent=false,ParentId=61,IconCss = "nav-icon far fa-circle text-info",Url = "/SorumluKullanıcı/Index",Row=3},
                new SideBarMenuItem{Id=64,Name="Iş",IsParent=false,ParentId=61,IconCss = "nav-icon far fa-circle text-info",Url = "/Iş/Index",Row=4},
                new SideBarMenuItem{Id=65,Name="Iş Emri",IsParent=false,ParentId=61,IconCss = "nav-icon fa-solid fa-receipt",Url = "/IşEmri/Index",Row=1},






                new SideBarMenuItem{Id=41,Name="Depo",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Depo/Index",Row=12},


                new SideBarMenuItem{Id=59,Name="Yönetim",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=60,Name="Program",IsParent=false,ParentId=59,IconCss = "nav-icon far fa-circle text-info",Url = "/Program/Index",Row=1},




                //Kullanıcı İşlemleri 
                new SideBarMenuItem{Id=43,Name="Cariler",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=58,Name="Cariler",IsParent=false,ParentId=43,IconCss = "nav-icon far fa-circle text-info",Url = "/Cari/Cariler",Row=1},
                new SideBarMenuItem{Id=44,Name="Müşteriler",IsParent=false,ParentId=43,IconCss = "nav-icon far fa-circle text-info",Url = "/Cari/Müşteriler",Row=1},
                new SideBarMenuItem{Id=45,Name="Tedarikçiler",IsParent=false,ParentId=43,IconCss = "nav-icon far fa-circle text-info",Url = "/Cari/Tedarikçiler",Row=2},



               new SideBarMenuItem{Id=46,Name="Şantiye",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=47,Name="Şantiyeler",IsParent=false,ParentId=46,IconCss = "nav-icon far fa-circle text-info",Url = "/Şantiye/Index",Row=1},



               new SideBarMenuItem{Id=48,Name="Stok",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
               new SideBarMenuItem{Id=49,Name="Stok",IsParent=false,ParentId=48,IconCss = "nav-icon far fa-circle text-info",Url = "/Stok/Index",Row=1},
               new SideBarMenuItem{Id=50,Name="Hızlı Stok Kartı Oluştur",IsParent=false,ParentId=48,IconCss = "nav-icon far fa-circle text-info",Url = "/Stok/HızlıStokKartıOluştur",Row=1},



               new SideBarMenuItem{Id=66,Name="Belge Tasarımı",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
               new SideBarMenuItem{Id=67,Name="Tasarlanmış Belgeler",IsParent=false,ParentId=66,IconCss = "nav-icon far fa-circle text-info",Url = "/BelgeTasarım/Belgeler",Row=1},
               //new SideBarMenuItem{Id=67,Name="Tasarlanmış Belgeler",IsParent=false,ParentId=66,IconCss = "nav-icon far fa-circle text-info",Url = "/BelgeTasarım/Index",Row=1},




                 new SideBarMenuItem{Id=51,Name="DosyaYönetimi",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/DosyaYönetimi/Index",Row=12},




                new SideBarMenuItem{Id=52,Name="KareKod",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=53,Name="İş Emirleri",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/Karekod/Index",Row=1},
                new SideBarMenuItem{Id=54,Name="Bildirim Emirleri",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/KareKod/BildirimEmirleri",Row=1},
                new SideBarMenuItem{Id=68,Name="Ana Urunler",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/KareKod/AnaUrunler",Row=1},
                new SideBarMenuItem{Id=72,Name="İstasyonlar",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/KareKod/Istasyon",Row=1},
                new SideBarMenuItem{Id=75,Name="Aktarım",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/KareKod/Aktarım",Row=1},
                      new SideBarMenuItem{Id=77,Name="Müşteriler",IsParent=false,ParentId=52,IconCss = "nav-icon far fa-circle text-info",Url = "/KareKod/Müşteriler",Row=1},


                new SideBarMenuItem{Id=55,Name="Tanımlar",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=56,Name="Stok Kodu Tanımı",IsParent=false,ParentId=55,IconCss = "nav-icon far fa-circle text-info",Url = "/Tanımlar/StokKoduTanım",Row=1},
                new SideBarMenuItem{Id=57,Name="Cari Kodu Tanımı",IsParent=false,ParentId=55,IconCss = "nav-icon far fa-circle text-info",Url = "/Tanımlar/CariKoduTanım",Row=1},
                new SideBarMenuItem{Id=78,Name="Depo Kodu Tanımı",IsParent=false,ParentId=55,IconCss = "nav-icon far fa-circle text-info",Url = "/Tanımlar/DepoKoduTanım",Row=1},
                new SideBarMenuItem{Id=79,Name="Kasa Kodu Tanımı",IsParent=false,ParentId=55,IconCss = "nav-icon far fa-circle text-info",Url = "/Tanımlar/KasaKoduTanım",Row=1},




                new SideBarMenuItem{Id=69,Name="Fabrika Makina Yönetimi",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=70,Name="İlaç Fırın",IsParent=false,ParentId=69,IconCss = "nav-icon far fa-circle text-info",Url = "/FabrikaMakinaYönetimi/Fırın",Row=1},


                new SideBarMenuItem{Id=73,Name="Döküman Yönetimi",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=74,Name="Dökümanlar",IsParent=false,ParentId=73,IconCss = "nav-icon far fa-circle text-info",Url = "/Döküman/Index",Row=1},


                 new SideBarMenuItem{Id=82,Name="Seri No Tanımları",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=83,Name="Fatura Seri No Tanımı",IsParent=false,ParentId=82,IconCss = "nav-icon far fa-circle text-info",Url = "/SeriNo/FaturaSeriNoTanım",Row=1},
                new SideBarMenuItem{Id=84,Name="Ödeme Seri No Tanımı",IsParent=false,ParentId=82,IconCss = "nav-icon far fa-circle text-info",Url = "/SeriNo/ÖdemeSeriNoTanım",Row=1},


                new SideBarMenuItem{Id=85,Name="Kasa",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=86,Name="Kasa",IsParent=false,ParentId=85,IconCss = "nav-icon far fa-circle text-info",Url = "/Kasa/Index",Row=1},
               
                
                
                //88

            };

            modelBuilder.Entity<SideBarMenuItem>().HasData(sideBarMenuItems);
        }
    }
}
