using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Contants
{
    public static class LogMessage
    {
        public const string Login = "Sisteme giriş yapıldı.";
        public const string Logout = "Sistemden çıkış yapıldı.";
        public const string Contact = "Yönetici kullanıcılara yorumda bulunuldu.";
        public const string MailSended = "Yönetici kullanıcılara mail gönderildi.";
        public const string ErrorPage = "Error sayfasına gönderildi.";
        public const string Error404 = "Error 404 sayfasına gönderildi.";
        public const string Error500 = "Error 404 sayfasına gönderildi.";
        public const string MenuItemAdded = "Yeni menü elemanı eklendi";
        public const string MenuItemDeleted = " id numaralı Menü elemanı silindi.";
        public const string MenuItemEdit = " id numaralı Menü elemanı düzenlendi.";
        public const string CountryAdded = "Yeni ülke eklendi.";
        public const string CountryEdit = " id numaralı Menü elemanı düenlendi.";
        public const string CountryDeleted = " id numaralı ülke silindi.";
        public const string SystemAdminIndex = "System Admin sayfası görüntülendi.";
        public const string ContactListPage = "Contact List sayfası görüntülendi.";
        public const string ContactInformationPage = " id numaralı Contact görüntülendi.";
        public const string ContactDelete = " id numaralı Contact silindi.";
        public const string Accessdenied = "Yetkili olmayan sayfaya giriş denemesi yapıldı.";
        public const string LanguageSelect = "Dil seçimi yapıldı.";
        public const string IncorrectLogins = " hatalı giriş denemesi.";
        public const string UserNotFound = " hatalı kullanıcı giriş denemesi.";
        public const string LockoutEndUser = " kilitli kullanıcı giriş denemesi.";
        public const string BannedUserLogin = " yasaklı kullanıcı giriş denemesi.";
        public const string ForgotPassword = " mail adresi kullanıcısına yeni şifre linki gönderildi.";
        public const string ResetPassword = "Şifre yenileme ekranına yönlendirildi.";
        public const string ResetPasswordCompleted = "Şifre yenileme işlemi tamamlandı.";
        public const string ResetPasswordNotCompleted = "Şifre yenileme işlemi tamamlanamdı.";
        public const string AccountInformationSeen = "Hesap bilgileri görüntülendi.";
        public const string ChangePasswordStart = "Şifre değiştirme işlemine başlandı.";
        public const string ChangePasswordEnd = " id numaralı hesabın şifre değiştirme işlemi tamamlandı.";
        public const string ChangePasswordError = "Şifre değiştirme işleminde hata meydana geldi.";
        public const string ChangeMyAccountInformationStart = "Hesap bilgileri değiştirme işlemine başlandı.";
        public const string ChangeMyAccountInformationEnd = " id numaralı hesab bilgileri değiştirme işlemi tamamlandı.";
        public const string ChangeMyAccountInformationError = "Hesap bilgileri değiştirme işleminde hata meydana geldi.";
        public const string ChangePhoto = "Profil fotoğrafı değiştirildi.";
        public const string SearchDevice = " alan değerleri ile Device araması yapıldı.";
        public const string SelectedDeviceList = " id değerli deviceler seçildi.";
        public const string DeviceInfo = " id değerli device görüntülendi.";
        public const string DeviceEventList = " id değerli device'nin Event bilgileri görüntülendi.";
        public const string DeviceAdd = " id değerli device eklendi.";
        public const string DeviceDelete = " id değerli device silindi.";
        public const string DeviceEdit = " id değerli device düzenlendi.";
        public const string DeviceCardReadingLogInfo = " id değerli device log bilgileri görüntülendi.";
        public const string BatchDeviceList = " id değerli device liste halinde eklendi.";
        public const string AssingEvent = " arasında event atama işlemi uygulandı.";
        public const string MultipleChangeStatus = " id değerli devicelerin statudleri değiştirildi. Atanan değer: ";
        public const string SearchSystemUserLog = " alan değerleri ile SystemUserLog araması yapıldı.";
        public const string SearchImplementer = " alan değerleri ile Implementer araması yapıldı.";
        public const string ImplementerDelete = " id değerli Implementer silindi.";
        public const string ImplementerInfo = " id değerli Implementer görüntülendi.";
        public const string ImplementerSystemInformation = " id değerli Implementer'ın Sistem Bilgileri görüntülendi.";
        public const string ImplementerEdit = " id değerli Implementer düzenlendi.";
        public const string ImplementerAdd = " id değerli Implementer eklendi.";
        public const string SearchProject = " alan değerleri ile Project araması yapıldı.";
        public const string ProjectList = " id değerli Implementera ait projeler görüntülendi.";
        public const string ProjectAdd = " id değerli Proje eklendi.";
        public const string ProjectDelete = " id değerli Project silindi.";
        public const string ProjectInfo = " id değerli Proje görüntülendi.";
        public const string ProjectEdit = " id değerli Proje düzenlendi.";
        public const string ProjectUsers = " id değerli Proje kullanıcıları görüntülendi.";
        public const string ProjectAssignUserUpdate = " id değerli Proje kullanıcıları güncellendi.";
        public const string RoleList = "Tüm roller görüntülendi.";
        public const string RoleCreate = " id numaralı yeni rol eklendi.";
        public const string RoleNotCreate = " id numaralı yeni rol eklenirken hata meydana geldi.";
        public const string RoleDelete = " id numaralı yeni rol silindi.";
        public const string RoleNotDelete = " id numaralı yeni rol silinirken hata meydana geldi.";
        public const string RoleEdit = "  id numaralı Rol düzenlendi.";
        public const string RoleNotEdit = "  id numaralı Rol düzenlenirken hata meydana geldi.";
        public const string EditUserInRole = "  id numaralı Rol kullanıcıları düzenlendi.";
        public const string EditUserInRoleNot = "  id numaralı Rol kullanıcıları düzenlendi.";
        public const string EditPermissionInRole = "  id numaralı Rol izinleri düzenlendi.";
        public const string EditPermissionInRoleNot = "  id numaralı Rol izinleri düzenlenirken hata meydana geldi.";
        public const string AdminAdded = "  yönetici olarak eklendi";
        public const string AdminRemoved = "  yönetici olmaktan çıkartıldı.";
        public const string UserAddedOther = "  rolünde yeni kullanıcı eklendi";
        public const string ProjectAdded = " id değerli Proje eklendi.";
        public const string ProjectAdminUserAdded = " id değerli Proje yöneticisi eklendi.";
        public const string ProjectDeleted = " id değerli Proje silindi.";
        public const string ProjectSystemInformation = " id değerli Project'in Sistem Bilgileri görüntülendi.";
        public const string EventSystemInformation = " id değerli Event'in Sistem Bilgileri görüntülendi.";
        public const string EventAdd = " id değerli Event eklendi.";
        public const string EventDelete = " id değerli Event silindi.";
        public const string EventEdit = " id değerli Event düzenlendi.";
        public const string SearchEvent = " alan değerleri ile Event araması yapıldı.";
        public const string EventList = " id değerli Project'e ait Event'lar görüntülendi.";
        public const string SearchUser = " alan değerleri ile User araması yapıldı.";
        public const string UserInformation = " id değerli Sistem Kullanıcısı bilgileri görüntülendi.";
        public const string UserEdit = "  id numaralı sistem kullanıcısı düzenlendi.";
        public const string UserDeleted = " id değerli sistem kullanıcısı silindi.";
        public const string UserAdded = " id değerli sistem kullanıcısı eklendi.";
        public const string UserRoleAdded = " adlı rol sistem kullanıcısına eklendi.";
        public const string UserPasswordInformationMailSended = " id numaralı sistem kullanıcısına kullanıcı bilgileri mail olarak gönderildi.";
        public const string BeneficiaryAdded = " id değerli Beneficiary eklendi.";
        public const string BeneficiaryListAdded = " id değerli Beneficiary liste içerisinde eklendi.";
        public const string BeneficiaryDeleted = " id değerli Beneficiary silindi.";
        public const string SearchBeneficiary = " alan değerleri ile Beneficiary araması yapıldı.";
        public const string SaveSelectedBeneficiary = " Beneficiary'leri işlem yapılmak üzere seçildi.";
        public const string BeneficiaryInformation = " id numaralı Beneficiary görüntülendi.";
        public const string BeneficiaryEventsAndProject = " id numaralı Beneficiary'in Event ve Projet bilgisi görüntülendi.";
        public const string BeneficiaryTransaction = " id numaralı Beneficiary'in Transaction bilgisi görüntülendi.";


        //Synchronization log messages
        public const string SynchronizationGenerateKey = "Synchronization işlemi için key üretildi. Key:";
        public const string SynchronizationGenerateKeySystemUser = " id numaralı Device synchronization işlemi için key üretildi.";
        public const string SynchronizationSuccessSystemUser = " id numaralı Device synchronization işlemi başarılıdır.";
        public const string SynchronizationFailSystemUser = " id numaralı Device synchronization işlemi başarısızdır.";
        public const string SynchronizationSuccess = "Device synchronization işlemi başarılıdır.";
        public const string SynchronizationFail = "Device synchronization işlemi başarısızdır.";




        //Transaction Log Messages
        public const string TransactionInformation = " id Numaralı Transaction Bilgileri Görüntülendi";
        public const string TransactionAllInformation = " Tüm Transactionlar istendi";
        public const string TransactionAdd = " id Numaralı Transaction Eklendi ";

        public const string TransactionDeviceInformation = " id Numaralı Transaction Device bilgileri istendi ";
        public const string TransactionEventInformation = " id Numaralı Transaction Event bilgileri istendi ";
        public const string TransactionBeneficiaryInformation = " id Numaralı Transaction Beneficiary bilgileri istendi ";

        public const string TransactionAddFromDevice = " id Numaralı Device Tarafından  ";
        public const string TransactionDelete = " id Numaralı Transaction Silindi";
        public const string TransactionSearch = " Değerleri İle Transaction Araması Yapıldı";




        //Annoucument Log Messages
        public const string AnnoucumentInformation = " id Numaralı Annoucument Bilgileri Görüntülendi";
        public const string AnnoucumentContextInformation = " id numaralı Annoucument Context Bilgileri Görüntülendi";
        public const string AnnouncumnetAdd = " id Numaralı Announcumnet Eklendi";
        public const string AnnouncumnetDelete = " id Numaralı Announcumnet Silindi";
        public const string AnnouncumnetEdit = " id Numaralı Announcumnet Düzenlendi";














    }
}
