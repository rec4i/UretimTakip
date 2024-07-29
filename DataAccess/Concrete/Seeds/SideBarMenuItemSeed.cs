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
                new SideBarMenuItem{Id=1,Name="Ayarlar",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-gear",Url = "#",Row=1},
                new SideBarMenuItem{Id=2,Name="Menü Ayarları",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/MenuList",Row=1},
                new SideBarMenuItem{Id=3,Name="Log Arama",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/SystemUserLogListSearch",Row=2},
                new SideBarMenuItem{Id=4,Name="Ulke Ayarları",IsParent=false,ParentId=1,IconCss = "nav-icon far fa-circle text-info",Url = "/Setting/CountryList",Row=3},

                //Role Ayarları
                new SideBarMenuItem{Id=5,Name="Role İşlemleri",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-address-card",Url = "#",Row=2},
                new SideBarMenuItem{Id=6,Name="Rol Listesi",IsParent=false,ParentId=5,IconCss = "nav-icon far fa-circle text-info",Url = "/Role/RoleList",Row=1},
                new SideBarMenuItem{Id=7,Name="Rol Ekle",IsParent=false,ParentId=5,IconCss = "nav-icon far fa-circle text-info",Url = "/Role/CreateRole",Row=2},

                //Kullanıcı İşlemleri 
                new SideBarMenuItem{Id=8,Name="Kullanıcı İşlemleri",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-user-group",Url = "#",Row=3},
                new SideBarMenuItem{Id=9,Name="Arama",IsParent=false,ParentId=8,IconCss = "nav-icon far fa-circle text-info",Url = "/User/Search",Row=1},
                new SideBarMenuItem{Id=10,Name="Kullanıcı Ekle",IsParent=false,ParentId=8,IconCss = "nav-icon far fa-circle text-info",Url = "/User/AddUser",Row=2},

         

                //Diğer İşlemler  
                new SideBarMenuItem{Id=28,Name="Diğer İşlemler",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-chalkboard-user",Url = "#",Row=9},
                new SideBarMenuItem{Id=29,Name="Bize Yazanlar",IsParent=false,ParentId=28,IconCss = "nav-icon far fa-circle text-info",Url = "/SystemAdmin/ContactList",Row=10},

                //Hesabım
                new SideBarMenuItem{Id=30,Name="Hesabım",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-address-card",Url = "/Account/accountinformation",Row=11},
               
                //Çıkış Yap
                new SideBarMenuItem{Id=31,Name="Çıkış Yap",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Account/Logout",Row=12},


                //new SideBarMenuItem{Id=32,Name="Transactions",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "#",Row=12},
                //new SideBarMenuItem{Id=33,Name="Transactions",IsParent=false,ParentId=32,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Transaction/AllTransactions",Row=12},

                new SideBarMenuItem{Id=34,Name="Announcement",IsParent=true,ParentId=null,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "#",Row=12},
               // new SideBarMenuItem{Id=35,Name="Announcement List",IsParent=false,ParentId=34,IconCss = "nav-icon fa-solid fa-right-from-bracket",Url = "/Ann
                new SideBarMenuItem{Id=36,Name="Reçete",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Reçete/Index",Row=12},
                new SideBarMenuItem{Id=37,Name="Stok",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Stok/Index",Row=12},

                    new SideBarMenuItem{Id=38,Name="Tezgah",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Tezgah/Index",Row=12},


                             new SideBarMenuItem{Id=39,Name="Iş",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Iş/Index",Row=12},
                              new SideBarMenuItem{Id=40,Name="Iş Emri",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/IşEmri/Index",Row=12},


                  new SideBarMenuItem{Id=41,Name="Depo",IsParent=false,ParentId=null,IconCss = "nav-icon fa-solid fa-receipt",Url = "/Depo/Index",Row=12},
            };

            modelBuilder.Entity<SideBarMenuItem>().HasData(sideBarMenuItems);
        }
    }
}
