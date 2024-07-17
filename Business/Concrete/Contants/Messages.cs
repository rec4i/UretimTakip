using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string WrongInformation = "Bilgileri kontrol ederek tekrar gonderiniz.";
        public static string UserNotFound = "Girmiş olduğunuz kullanıcı bulunamadı";
        public static string BannedUser = "Yönetici tarafından yasaklandığınızdan dolayı sisteme giriş yapamazsınız.";
        public static string LockoutEnd = "5 defa yanlış giriş denemesi yapıldığından hesabınız 10 dakikalığına kitlenmiştir. Sonra tekrar deneyiniz.";
        public static string UsernamePasswordIncorrect = "Kullanıcı adı veya şifre yanlış!";
        public static string UserNameUsed = "Bu kullanıcı adı daha önceden kullanılmıştır, başka bir kullanıcı adı deneyiniz!";
        public static string EmailUsed = "Bu mail adresi daha önceden kullanılmıştır, başka bir kullanıcı adı deneyiniz!";
        public static string NotFoundRole = "İlgili Rol Bulunamadı!";
        public static string Successful = "İşlem başarılı!";
        public static string Fail = "Bir sıkınntı meydana geldi, lütfen daha sonra tekrar deneyiniz.";
        public static string RoleNotDeleted = "Role silinemedi, lütfen roleId'ni kontrol ediniz";
        public static string InvalidMailAdress = "Lütfen geçerli bir mail adresi giriniz.";
        public static string SendPasswordResetMail = "Şifre sıfırlama linki e-postanıza gönderildi, lütfen kontrol ediniz.";
        public static string UnauthorizedUser = "Bu işlemi yapmak için yetkiniz bulunmamaktadır.";
        public static string SuccessChangePassword = "Sifre degistirme isleminiz basarli bir sekilde tamamlanmistir";
        public static string SuccessChangePersonalInformation = "Kullanıcı bilgileri degistirme isleminiz basarli bir sekilde tamamlanmistir";
        public static string UserRoleRequired = "En az bir adet kullanıcı rolü olmaldıdır.";
        public static string PasswordContainsUserName = "Şifre kullanıcı adı içeremez";
        public static string PasswordContainsConsecutive = "Şifre ard arda 3 ardışık sayı veya harf içeremez";
        public static string UsernameCannotStartWithaDigit = "Kullanıcı adı rakam ile başlayamaz";
        public static string ImplementerNotFound = "Uygulayıcı bulunamadı!";
        public static string ImplementerDontSave = "Kullanıcı kaydedildi ama uygulayıcı atama işlemi başarısız!";
        public static string ImplementerChoose = "Lütfen proje eklemek istediğiniz Uygulayıcıyı seçiniz!";
        public static string NotFoundEvent = "İlgili Event Bulunamadı!";
        public static string BeneficiaryNotFound ="İlgili Beneficiary Bulunamadı!";
        public static string AddedFailed = "Ekleme işlemi başarısız";
        public static string AddedSuccess = "Ekleme işlemi başarılı.";
        public static string ClientNotFound = "Client Id veya Secret bulunamadı";
        public static string RefreshTokenNotFound = "RefreshToken bulunamadı";
        public static string UserIdNotFound = "UserId bulunamadı";
        public static string AddEventToDevice = " id numaralı event atama işlemi yapıldı.";
        public static string RemoveEventToDevice = " id numaralı event kaldırma işlemi yapıldı.";
    }
}
