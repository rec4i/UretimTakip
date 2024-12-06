using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Entities.Concrete.Contants
{
    public static class Permission
    {
        public static class User
        {
            public const string Search = "Permission.User.Search";
            public const string UserInformation = "Permission.User.UserInformation";
            public const string EditUserInformation = "Permission.User.EditUserInformation";
            public const string UserDelete = "Permission.User.UserDelete";
            public const string AddUser = "Permission.User.AddUser";
            public const string ImplementerAssignUser = "Permission.User.ImplementerAssignUser";
            public const string AllUserList = "Permission.User.AllUserList";
        }
        public static class ViewComponents
        {
            public const string ImplementerWorldMap = "Permission.ViewComponents.ImplementerWorldMap";
        }
        public static class Tools
        {
            public const string UploadImage = "Permission.Tools.UploadImage";
        }
        public static class Home
        {
            public const string Contact = "Permission.Home.Contact";
        }
        public static class SystemAdmin
        {
            public const string Index = "Permission.SystemAdmin.Index";
            public const string ContactList = "Permission.SystemAdmin.ContactList";
            public const string ContactInformation = "Permission.SystemAdmin.ContactInformation";
            public const string ContactDelete = "Permission.SystemAdmin.ContactDelete";
        }
        public static class Role
        {
            public const string RoleList = "Permission.Role.RoleList";
            public const string CreateRole = "Permission.Role.CreateRole";
            public const string RoleDelete = "Permission.Role.RoleDelete";
            public const string RoleEdit = "Permission.Role.RoleEdit";
            public const string EditUserInRole = "Permission.Role.EditUserInRole";
            public const string EditPermissionInRole = "Permission.Role.EditPermissionInRole";
            public const string ImplementerRoleList = "Permission.Role.ImplementerRoleList";
            public const string CreateImplementerRole = "Permission.Role.CreateImplementerRole";
            public const string DeleteImplementerRole = "Permission.Role.DeleteImplementerRole";
            public const string ImplementerRoleEdit = "Permission.Role.ImplementerRoleEdit";
            public const string ImplementerEditPermissionInRole = "Permission.Role.ImplementerEditPermissionInRole";
            public const string ImplementerEditUserInRole = "Permission.Role.ImplementerEditUserInRole";
        }
        public static class Setting
        {
            public const string SystemUserLogListSearch = "Permission.Setting.SystemUserLogListSearch";
            public const string MenuList = "Permission.Setting.MenuList";
            public const string EditMenuItem = "Permission.Setting.EditMenuItem";
            public const string MenuItemDelete = "Permission.Setting.MenuItemDelete";
            public const string AnnouncementList = "Permission.Setting.AnnouncementList";
            public const string CountryList = "Permission.Setting.CountryList";
            public const string CountryAddAndEdit = "Permission.Setting.CountryAddAndEdit";
            public const string CountryDelete = "Permission.Setting.CountryDelete";
        }

        public static class Announcement
        {
            public const string AnnouncementList = "Permission.Announcement.AnnouncementList";
            public const string AddAnnouncement = "Permission.Announcement.AddAnnouncement";
            public const string DeleteAnnouncement = "Permission.Announcement.DeleteAnnouncement";
            public const string UpdateAnnouncement = "Permission.Announcement.UpdateAnnouncement";
        }

        public static class Order
        {
            public const string Index = "Permission.Order.Index";
            public const string AddOrder = "Permission.Order.AddOrder";
        }

        public static class Pharmacy
        {
            public const string AddPharmacy = "Permission.Pharmacy.AddPharmacy";
            public const string Index = "Permission.Pharmacy.Index";
            public const string AddPharmacyFromExel = "Permission.Pharmacy.AddPharmacyFromExel";
        }
        public static class Product
        {
            public const string AddProduct = "Permission.Product.AddProduct";
            public const string Index = "Permission.Product.Index";
            public const string EditProduct = "Permission.Product.EditProduct";
            public const string DeleteProduct = "Permission.Product.DeleteProduct";
        }

        public static class Unit
        {
            public const string Index = "Permission.Unit.Index";
            public const string AddUnit = "Permission.Unit.AddUnit";
        }
        public static class Profile
        {
            public const string Index = "Permission.Profile.Index";
        }
        public static class PharmacyListManager
        {
            public const string Index = "Permission.PharmacyListManager.Index";
        }

        public static class Doctor
        {
            public const string Index = "Permission.Doctor.Index";
            public const string AddDoctor = "Permission.Doctor.AddDoctor";
            public const string EditDoctor = "Permission.Doctor.EditDoctor";
        }

        public static class Reçete
        {
            public const string Index = "Permission.Reçete.Index";
        }

        public static class Stok
        {
            public const string Index = "Permission.Stok.Index";
        }


        public static class Tezgah
        {
            public const string Index = "Permission.Tezgah.Index";
        }
        public static class Iş
        {
            public const string Index = "Permission.Iş.Index";
        }
        public static class IşEmri
        {
            public const string Index = "Permission.IşEmri.Index";
        }

        public static class Depo
        {
            public const string Index = "Permission.Depo.Index";
        }

        public static class Program
        {
            public const string Index = "Permission.Program.Index";
            public const string ProgramAdd = "Permission.Program.ProgramAdd";
        }

        public static class Cari
        {
            public const string Cariler = "Permission.Cari.Cariler";
            public const string Müşteriler = "Permission.Cari.Müşteriler";
            public const string Tedarikçiler = "Permission.Cari.Tedarikçiler";
            public const string Index = "Permission.Cari.Index";

        }
        public static class Şantiye
        {
            public const string Index = "Permission.Şantiye.Index";

        }



        public static class Tanımlar
        {
            public const string StokKoduTanım = "Permission.Tanımlar.StokKoduTanım";
            public const string CariKoduTanım = "Permission.Tanımlar.CariKoduTanım";

        }
        public static class DosyaYönetimi
        {
            public const string Index = "Permission.DosyaYönetimi.Index";
            public const string YtkiVerme = "Permission.DosyaYönetimi.YtkiVerme";
            public const string DosyaYoluKaydet = "Permission.DosyaYönetimi.DosyaYoluKaydet";
        }


        public static class KareKod
        {
            public const string Index = "Permission.KareKod.Index";
            public const string BildirimEmirleri = "Permission.KareKod.BildirimEmirleri";
            public const string AnaUrunler = "Permission.KareKod.AnaUrunler";
            public const string UretimEkranı = "Permission.KareKod.UretimEkranı";
            public const string Istasyon = "Permission.KareKod.Istasyon";
            public const string Aktarım = "Permission.KareKod.Aktarım";
            public const string Müşteriler = "Permission.KareKod.Müşteriler";
        }

        public static class BelgeTasarım
        {
            public const string Index = "Permission.BelgeTasarım.Index";
        }

        public static class FabrikaMakinaYönetimi
        {
            public const string Fırın = "Permission.FabrikaMakinaYönetimi.Fırın";
        }

        public static class Döküman
        {
            public const string Index = "Permission.Döküman.Index";
        }


        //PharmacyListManager

        //fa-solid fa-cube
        //AddPharmacyFromExel

        public static IEnumerable<FieldInfo> GetPublicConstants(Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Concat(type.GetNestedTypes(BindingFlags.Public).SelectMany(GetPublicConstants));
        }
        public static List<string> GetPermissions()
        {
            var permissionList = new List<string>();
            foreach (var type in typeof(Permission).GetNestedTypes().ToList())
            {
                foreach (var item in GetPublicConstants(type))
                {
                    var resultName = (item.DeclaringType.FullName + "." + item.Name).Replace(typeof(Permission).Namespace + ".", "").Replace("+", ".");
                    permissionList.Add(resultName);
                }
            }
            return permissionList;
        }
    }
}


