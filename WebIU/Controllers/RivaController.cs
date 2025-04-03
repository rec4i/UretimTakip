using DocumentFormat.OpenXml.Bibliography;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static WebIU.Controllers.RivaController;
using Entities.Concrete.OtherEntities;
using System.Data;
using WebIU.Models.HelperModels;
using WebIU.Models.RivaViewModels;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Identity;
using Entities.Concrete.Identity;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using static WebIU.Controllers.KareKodController;
using System.Numerics;
using System.Linq;
using System.Globalization;

namespace WebIU.Controllers
{
    public class RivaController : Controller
    {
        //private string _connectionString = @"Server=localhost;Database=C:\Program Files (x86)\Riva\Entegra\Database\F5YAZILIM.SRV;User=F5;Password=f5;Charset=NONE;";
        //private string _connectionString = @"Server=localhost;Database=C:\Program Files (x86)\Riva\Entegra\Database\F5YAZILIM.SRV;User=SYSDBA;Password=masterkey;Charset=NONE;";
        private string _connectionString = @"Server=localhost;Database=C:\Program Files (x86)\Riva\Entegra\Database\F5YAZILIM.SRV;User=musa;Password=musa;Charset=NONE;";
        private readonly ISıcakSatışAyarRepository _sıcakSatışAyarRepository;
        private readonly ISıcakSatışButonProfilRepository _sıcakSatışButonProfilRepository;
        private readonly ISıcakSatışHızlıButonRepository _sıcakSatışHızlıButonRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        public RivaController(ISıcakSatışButonProfilRepository sıcakSatışButonProfilRepository,
            ISıcakSatışHızlıButonRepository sıcakSatışHızlıButonRepository, ISıcakSatışAyarRepository sıcakSatışAyarRepository, UserManager<AppIdentityUser> userManager, IHttpContextAccessor accessor)
        {
            _sıcakSatışButonProfilRepository = sıcakSatışButonProfilRepository;
            _sıcakSatışHızlıButonRepository = sıcakSatışHızlıButonRepository;
            _sıcakSatışAyarRepository = sıcakSatışAyarRepository;
            _userManager = userManager;

            var userId = _userManager.GetUserId(accessor.HttpContext.User);
            SıcakSatışAyar userAyar = new SıcakSatışAyar();

            if (userId == null)
            {
                userAyar = _sıcakSatışAyarRepository.Get(o => o.UserId == "65884dec-abf8-43a9-b52e-8065e20aea5a");

            }
            else
            {
                userAyar = _sıcakSatışAyarRepository.Get(o => o.UserId == userId);

            }
            SıcakSatışAyar entity = new SıcakSatışAyar();
            if (userAyar == null)
            {
                entity.UserId = userId;
                var addedEntity = _sıcakSatışAyarRepository.Add(entity);
                userAyar = addedEntity;
            }

            _connectionString = @"Server=localhost;Database=" + userAyar.RivaDbYolu + ";User=" + userAyar.RivaUser + ";Password=" + userAyar.RivaPass + ";Charset=NONE;";
            //_connectionString = @"Server=localhost;Database=" + userAyar.RivaDbYolu + ";User=SYSDBA;Password=masterkey;Charset=NONE;";
            //_connectionString = @"Server=localhost;Database=" + userAyar.RivaDbYolu + ";User=Riva;Password=riva;Charset=NONE;";
        }
        #region Models 
        public class CariHareketlerViewModel
        {
            public RivaCari rivaCari { get; set; }
            public List<RivaCariHareket> cariHareket { get; set; }
        }
        public class FaturaGörünümViewModel
        {
            public FaturaDto FaturaBaşlık { get; set; }
            public RivaCari RivaCari { get; set; }

            public List<FaturaDetayDto> FaturaDetayDtos { get; set; }

        }
        public class CariHarehetYazdırViewModel
        {
            public RivaCari Cari { get; set; }
            public List<RivaCariHareket> CariHareketler { get; set; }
            public List<RivaFatura> RivaFaturas { get; set; }
            public List<FaturaDetayDto> RivaFaturaSatırs { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public bool Detaylımı { get; set; }
        }
        public class FaturaYazdırViewModel
        {
            public FaturaDto RivaFatura { get; set; }
            public List<FaturaDetayDto> RivaFaturaSatırs { get; set; }
            public RivaCari Cari { get; set; }

        }
        public class RivaStokHareketViewModel
        {
            public List<RivaStokHareket> StokHarekets { get; set; }
        }

        #endregion
        #region Entites 
        public class RivaStok
        {
            public int SK_ID { get; set; }
            public string SK_KOD { get; set; }
            public string SK_ISIM { get; set; }
            public int SK_TIP { get; set; }
            public string SK_URETICI_KODU { get; set; }
            public int SK_SATICI_ID { get; set; }
            public int SK_DEPO_ID { get; set; }
            public int SK_DOVIZ_ID { get; set; }
            public int SK_FIRE_ID { get; set; }
            public decimal SK_FIRE_ORANI { get; set; }
            public string SK_OLCU1_BIRIM { get; set; }
            public string SK_OLCU2_BIRIM { get; set; }
            public int SK_OLCU2_PAY { get; set; }
            public int SK_OLCU2_PAYDA { get; set; }
            public string SK_OLCU3_BIRIM { get; set; }
            public int SK_OLCU3_PAY { get; set; }
            public int SK_OLCU3_PAYDA { get; set; }
            public string SK_OLCU1_BARKOD { get; set; }
            public string SK_OLCU2_BARKOD { get; set; }
            public string SK_OLCU3_BARKOD { get; set; }
            public decimal SK_BIRIM_AGIRLIK { get; set; }
            public decimal SK_NAKLIYE_TUTARI { get; set; }
            public decimal SK_ASGARI_LIMIT { get; set; }
            public decimal SK_AZAMI_LIMIT { get; set; }
            public int SK_RISK_SURESI { get; set; }
            public int SK_TEMIN_SURESI { get; set; }
            public decimal SK_ALIS_KDV_ORANI { get; set; }
            public decimal SK_SATIS_KDV_ORANI { get; set; }
            public decimal SK_ISKONTO_ORANI { get; set; }
            public decimal SK_ASGARI_SIP_MIKTARI { get; set; }
            public decimal SK_KULLANIM_MIKTARI { get; set; }
            public int SK_NITELIK_SABLON_ID { get; set; }
            public bool SK_SERI_TAKIBI { get; set; }
            public bool SK_OTO_SERI_GIRIS { get; set; }
            public bool SK_OTO_SERI_CIKIS { get; set; }
            public string SK_SERI_ONDEGER { get; set; }
            public bool SK_MIKTAR_KADAR_SERI { get; set; }
            public bool SK_SERI_TEKRARSIZ { get; set; }
            public bool SK_LOT_TAKIBI { get; set; }
            public bool SK_OTO_LOT_GIRIS { get; set; }
            public bool SK_OTO_LOT_CIKIS { get; set; }
            public string SK_LOT_ONDEGER { get; set; }
            public int SK_OTV_TIPI { get; set; }
            public decimal SK_OTV_ORANI { get; set; }
            public decimal SK_GIRIS_MIKTARI { get; set; }
            public decimal SK_CIKIS_MIKTARI { get; set; }
            public decimal SK_GIRIS_TUTARI { get; set; }
            public decimal SK_CIKIS_TUTARI { get; set; }
            public decimal SK_MUS_SIPARIS_MIKTAR { get; set; }
            public decimal SK_MUS_SIPARIS_TAZMIN { get; set; }
            public decimal SK_SAT_SIPARIS_MIKTAR { get; set; }
            public decimal SK_SAT_SIPARIS_TAZMIN { get; set; }
            public bool SK_KILIT { get; set; }
            public int SK_MSB_DETAY_ID { get; set; }
            public string SK_NOTLAR { get; set; }
            public string SK_OZK_GRUP_KODU { get; set; }
            public string SK_OZK_MARKA_KODU { get; set; }
            public string SK_OZK_TIP_KODU { get; set; }
            public decimal SK_ALF_A { get; set; }
            public decimal SK_ALF_B { get; set; }
            public decimal SK_ALF_C { get; set; }
            public decimal SK_STF_A { get; set; }
            public decimal SK_STF_B { get; set; }
            public decimal SK_STF_C { get; set; }
            public decimal SK_DAF_A { get; set; }
            public decimal SK_DAF_B { get; set; }
            public decimal SK_DAF_C { get; set; }
            public decimal SK_DSF_A { get; set; }
            public decimal SK_DSF_B { get; set; }
            public decimal SK_DSF_C { get; set; }
            public string SK_MID_01 { get; set; }
            public string SK_MID_02 { get; set; }
            public string SK_MID_03 { get; set; }
            public string SK_MID_04 { get; set; }
            public string SK_MID_05 { get; set; }
            public string SK_MID_06 { get; set; }
            public string SK_MID_07 { get; set; }
        }
        public class FaturaDetayDto
        {
            public int FD_ID { get; set; }
            public string FD_ENTEGRA_TIP { get; set; }
            public int FD_ENTEGRA_ID { get; set; }
            public int FD_FATURA_ID { get; set; }
            public int FD_SIRA_NO { get; set; }
            public int FD_STOK_ID { get; set; }
            public string FD_STOK_BASLIK { get; set; }
            public int FD_CARI_ID { get; set; }
            public int FD_DEPO_ID { get; set; }
            public int FD_PLASIYER_ID { get; set; }
            public decimal FD_MIKTAR { get; set; }
            public decimal FD_MIKTAR2 { get; set; }
            public string FD_OLCU_BIRIMI { get; set; }
            public decimal FD_MAL_FAZLASI_ISK { get; set; }
            public int FD_DOVIZ_ID { get; set; }
            public decimal FD_DOVIZ_TUTAR { get; set; }
            public decimal FD_IADE_MALIYETI { get; set; }
            public decimal FD_TUTAR { get; set; }
            public decimal FD_KDV_ORANI { get; set; }
            public decimal FD_NAKLIYE_TUTARI { get; set; }
            public DateTime FD_TESLIM_TARIHI { get; set; }
            public int FD_VADE_GUNU { get; set; }
            public int FD_IRSALIYE_ID { get; set; }
            public int FD_IRSALIYE_DETAY_ID { get; set; }
            public decimal FD_OTV_TUTAR { get; set; }
            public int FD_MUHASEBE_ID { get; set; }
            public int FD_SIPARIS_ID { get; set; }
            public int FD_SIPARIS_DETAY_ID { get; set; }
            public decimal FD_SIPARIS_TAZMIN { get; set; }
            public string FD_SIS_01 { get; set; }
            public string FD_SIS_02 { get; set; }
            public string FD_SIS_03 { get; set; }
        }
        public class FaturaDto
        {
            public int FT_ID { get; set; }
            public string FT_EVRAK_TIPI { get; set; }
            public string FT_EVRAK_NO { get; set; }
            public int FT_CARI_ID { get; set; }
            public string FT_UNVAN { get; set; }
            public string FT_ADRES { get; set; }
            public string FT_ILCE { get; set; }
            public string FT_IL { get; set; }
            public string FT_POSTA_KODU { get; set; }
            public string FT_VERGI_DAIRESI { get; set; }
            public string FT_VERGI_NUMARASI { get; set; }
            public string FT_BABA_ADI { get; set; }
            public string FT_DOGUM_YERI { get; set; }
            public DateTime? FT_DOGUM_TARIHI { get; set; }
            public string FT_BAGKUR_DAIRESI { get; set; }
            public string FT_BAGKUR_NUMARASI { get; set; }
            public string FT_TC_KIMLIK_NUMARASI { get; set; }
            public string FT_ACIKLAMA { get; set; }
            public string FT_TIP { get; set; }
            public DateTime FT_TARIH { get; set; }
            public int FT_ZAMAN { get; set; }
            public DateTime FT_VADE_TARIHI { get; set; }
            public DateTime FT_KDV_VADE_TARIHI { get; set; }
            public DateTime FT_TESLIM_TARIHI { get; set; }
            public decimal FT_LISTE_FIYATI { get; set; }
            public int FT_DOVIZ_ID { get; set; }
            public DateTime FT_DOVIZ_KUR_TARIHI { get; set; }
            public decimal FT_DOVIZ_TUTAR { get; set; }
            public int FT_DEPO_ID { get; set; }
            public int FT_PLASIYER_ID { get; set; }
            public decimal FT_BRUT_TOPLAM { get; set; }
            public decimal FT_MAL_FAZLASI_ISK { get; set; }
            public decimal FT_SATIR_ISK_TOPLAMI { get; set; }
            public decimal FT_GENEL_ISK_MATRAHI { get; set; }
            public decimal FT_GENEL_ISK_TOPLAMI { get; set; }
            public decimal FT_MUS_STOPAJ { get; set; }
            public decimal FT_MUS_FON { get; set; }
            public decimal FT_MUS_BORSA { get; set; }
            public decimal FT_MUS_MERA { get; set; }
            public decimal FT_MUS_BAGKUR { get; set; }
            public decimal FT_MUS_KES_TOPLAMI { get; set; }
            public int FT_KALEM_SAYISI { get; set; }
            public decimal FT_TOPLAM_MIKTAR { get; set; }
            public decimal FT_TOPLAM_AGIRLIK { get; set; }
            public decimal FT_NAKLIYE_TUTARI { get; set; }
            public decimal FT_NAKLIYE_TUTARI_KDV { get; set; }
            public decimal FT_EK_MALIYET_TOPLAMI { get; set; }
            public decimal FT_VADE_FARKI { get; set; }
            public decimal FT_VADE_FARKI_KDV { get; set; }
            public decimal FT_KDV_TOPLAMI { get; set; }
            public decimal FT_KDV_TOPLAMI_YUV { get; set; }
            public decimal FT_GENEL_TOPLAM { get; set; }
            public decimal FT_GENEL_TOPLAM_YUV { get; set; }
            public decimal FT_KDV_DAHIL { get; set; }
            public decimal FT_KDV_ISK_ONCE_DUS { get; set; }
            public decimal FT_KDV_MAL_FAZLASI { get; set; }
            public decimal FT_KDV_MAL_FAZLA_NET { get; set; }
            public string FT_CARIYE_KAYIT { get; set; }
            public bool FT_PESINAT_AYRILSIN { get; set; }
            public bool FT_STOKLARA_KAYIT { get; set; }
            public DateTime? FT_STOK_IRS_TARIHI { get; set; }
            public decimal FT_STOK_MAL_EK_MALIYET { get; set; }
            public decimal FT_STOK_MAL_NAKLIYE { get; set; }
            public bool FT_KAPATILMIS { get; set; }
            public bool FT_KARSILANMIS { get; set; }
            public string FT_NOTLAR { get; set; }
            public string FT_SIS_01 { get; set; }
            public string FT_SIS_02 { get; set; }
            public string FT_SIS_03 { get; set; }
            public string FT_GIS_01 { get; set; }
            public string FT_GIS_02 { get; set; }
            public string FT_GIS_03 { get; set; }
            public string FT_EMT_01 { get; set; }
            public string FT_EMT_02 { get; set; }
            public string FT_EMT_03 { get; set; }
            public string FT_EMK_01 { get; set; }
            public string FT_EMK_02 { get; set; }
            public string FT_EMK_03 { get; set; }
        }
        public class InfinityResponse<T>
        {
            public List<T> Data { get; set; }
            public object Data2 { get; set; }
            public bool HasMore { get; set; }
        }
        public class RivaCariHareket
        {
            public int CH_ID { get; set; } // Anahtar alan, genelde int olur
            public string CH_ENTEGRA_TIP { get; set; } // Entegre tipi, genelde string
            public int? CH_ENTEGRA_ID { get; set; } // Nullable, çünkü boş olabilir
            public int? CH_CARI_ID { get; set; } // Cari ID, genelde nullable
            public DateTime? CH_ISLEM_TARIHI { get; set; } // İşlem tarihi
            public string CH_ISLEM_TIPI { get; set; } // İşlem tipi, genelde string
            public string CH_EVRAK_NO { get; set; } // Evrak numarası
            public string CH_ACIKLAMA { get; set; } // Açıklama
            public DateTime? CH_VADE_TARIHI { get; set; } // Vade tarihi
            public int? CH_PLASIYER_ID { get; set; } // Plasiyer ID
            public int? CH_DOVIZ_ID { get; set; } // Döviz ID
            public decimal? CH_DOVIZ_TUTAR { get; set; } // Döviz tutarı
            public decimal? CH_TUTAR { get; set; } // Tutar
            public decimal? CH_KAPATILMIS_TUTAR { get; set; } // Kapatılmış tutar
            public DateTime? CH_EVRAK_TARIHI { get; set; } // Evrak tarihi
            public string CH_IBAN { get; set; } // IBAN
            public string CH_EFT_TIPI { get; set; } // EFT tipi
        }
        public class RivaCari
        {
            public int CA_ID { get; set; }
            public string CA_KOD { get; set; }
            public string CA_UNVAN { get; set; }
            public int? CA_CARI_TIP_ID { get; set; }
            public string CA_ADRES { get; set; }
            public string CA_ILCE { get; set; }
            public string CA_IL { get; set; }
            public string CA_POSTA_KODU { get; set; }
            public string CA_VERGI_DAIRESI { get; set; }
            public string CA_VERGI_NUMARASI { get; set; }
            public int? CA_ULKE_ID { get; set; }
            public string CA_TC_KIMLIK_NO { get; set; }
            public int? CA_MUHASEBE_ID { get; set; }
            public int? CA_PLASIYER_ID { get; set; }
            public decimal? CA_LISTE_FIYATI { get; set; }
            public int? CA_DOVIZ_ID { get; set; }
            public decimal? CA_ISKONTO_ORANI { get; set; }
            public decimal? CA_NAKLIYE_KATSAYISI { get; set; }
            public int? CA_ODEME_GUNU { get; set; }
            public int? CA_VADE_GUNU { get; set; }
            public DateTime? CA_MUTABAKAT_TARIHI { get; set; }
            public decimal? CA_MUTABAKAT_BAKIYE { get; set; }
            public DateTime? CA_MUT_MEKTUP_TARIHI { get; set; }
            public decimal? CA_MUT_MEKTUP_BAKIYE { get; set; }
            public decimal? CA_RISK_LIMITI { get; set; }
            public decimal? CA_TEMINAT_TUTARI { get; set; }
            public decimal? CA_CEK_ASIL_RISKI { get; set; }
            public decimal? CA_CEK_CIRO_RISKI { get; set; }
            public decimal? CA_SENET_ASIL_RISKI { get; set; }
            public decimal? CA_SENET_CIRO_RISKI { get; set; }
            public decimal? CA_BORC { get; set; }
            public decimal? CA_ALACAK { get; set; }
            public string CA_NOTLAR { get; set; }
            public string CA_KTA_BOLGE_KODU { get; set; }
            public string CA_KTA_GRUP_KODU { get; set; }
            public string CA_KTA_OZEL_KOD { get; set; }
            public string CA_TLF_CEP { get; set; }
            public string CA_TLF_FAKS { get; set; }
            public string CA_TLF_TELEFON { get; set; }
        }
        public class RivaFatura
        {
            public int FT_ID { get; set; }
            public string FT_EVRAK_TIPI { get; set; }
            public string FT_EVRAK_NO { get; set; }
            public int? FT_CARI_ID { get; set; }
            public string FT_UNVAN { get; set; }
            public string FT_ADRES { get; set; }
            public string FT_ILCE { get; set; }
            public string FT_IL { get; set; }
            public string FT_POSTA_KODU { get; set; }
            public string FT_VERGI_DAIRESI { get; set; }
            public string FT_VERGI_NUMARASI { get; set; }
            public string FT_BABA_ADI { get; set; }
            public string FT_DOGUM_YERI { get; set; }
            public DateTime? FT_DOGUM_TARIHI { get; set; }
            public string FT_BAGKUR_DAIRESI { get; set; }
            public string FT_BAGKUR_NUMARASI { get; set; }
            public string FT_TC_KIMLIK_NUMARASI { get; set; }
            public string FT_ACIKLAMA { get; set; }
            public string FT_TIP { get; set; }
            public DateTime? FT_TARIH { get; set; }
            public TimeSpan? FT_ZAMAN { get; set; }
            public DateTime? FT_VADE_TARIHI { get; set; }
            public DateTime? FT_KDV_VADE_TARIHI { get; set; }
            public DateTime? FT_TESLIM_TARIHI { get; set; }
            public decimal? FT_LISTE_FIYATI { get; set; }
            public int? FT_DOVIZ_ID { get; set; }
            public DateTime? FT_DOVIZ_KUR_TARIHI { get; set; }
            public decimal? FT_DOVIZ_TUTAR { get; set; }
            public int? FT_DEPO_ID { get; set; }
            public int? FT_PLASIYER_ID { get; set; }
            public decimal? FT_BRUT_TOPLAM { get; set; }
            public decimal? FT_MAL_FAZLASI_ISK { get; set; }
            public decimal? FT_SATIR_ISK_TOPLAMI { get; set; }
            public decimal? FT_GENEL_ISK_MATRAHI { get; set; }
            public decimal? FT_GENEL_ISK_TOPLAMI { get; set; }
            public decimal? FT_MUS_STOPAJ { get; set; }
            public decimal? FT_MUS_FON { get; set; }
            public decimal? FT_MUS_BORSA { get; set; }
            public decimal? FT_MUS_MERA { get; set; }
            public decimal? FT_MUS_BAGKUR { get; set; }
            public decimal? FT_MUS_KES_TOPLAMI { get; set; }
            public int? FT_KALEM_SAYISI { get; set; }
            public decimal? FT_TOPLAM_MIKTAR { get; set; }
            public decimal? FT_TOPLAM_AGIRLIK { get; set; }
            public decimal? FT_NAKLIYE_TUTARI { get; set; }
            public decimal? FT_NAKLIYE_TUTARI_KDV { get; set; }
            public decimal? FT_EK_MALIYET_TOPLAMI { get; set; }
            public decimal? FT_VADE_FARKI { get; set; }
            public decimal? FT_VADE_FARKI_KDV { get; set; }
            public decimal? FT_KDV_TOPLAMI { get; set; }
            public decimal? FT_KDV_TOPLAMI_YUV { get; set; }
            public decimal? FT_GENEL_TOPLAM { get; set; }
            public decimal? FT_GENEL_TOPLAM_YUV { get; set; }
            public bool FT_KDV_DAHIL { get; set; }
            public bool FT_KDV_ISK_ONCE_DUS { get; set; }
            public bool FT_KDV_MAL_FAZLASI { get; set; }
            public bool FT_KDV_MAL_FAZLA_NET { get; set; }
            public bool FT_CARIYE_KAYIT { get; set; }
            public bool FT_PESINAT_AYRILSIN { get; set; }
            public bool FT_STOKLARA_KAYIT { get; set; }
            public DateTime? FT_STOK_IRS_TARIHI { get; set; }
            public decimal? FT_STOK_MAL_EK_MALIYET { get; set; }
            public decimal? FT_STOK_MAL_NAKLIYE { get; set; }
            public bool FT_KAPATILMIS { get; set; }
            public bool FT_KARSILANMIS { get; set; }
            public string FT_NOTLAR { get; set; }
            public decimal? FT_SIS_01 { get; set; }
            public decimal? FT_SIS_02 { get; set; }
            public decimal? FT_SIS_03 { get; set; }
            public decimal? FT_GIS_01 { get; set; }
            public decimal? FT_GIS_02 { get; set; }
            public decimal? FT_GIS_03 { get; set; }
            public string FT_EMT_01 { get; set; }
            public string FT_EMT_02 { get; set; }
            public string FT_EMT_03 { get; set; }
            public string FT_EMK_01 { get; set; }
            public string FT_EMK_02 { get; set; }
            public string FT_EMK_03 { get; set; }
        }
        public class RivaKasa
        {
            public int KS_ID { get; set; }
            public string KS_KOD { get; set; }
            public string KS_ISIM { get; set; }
            public int KS_DOVIZ_ID { get; set; }
            public int KS_MUHASEBE_ID { get; set; }
            public DateTime KS_DEVIR_TARIHI { get; set; }
            public decimal KS_DEVIR { get; set; }
            public decimal KS_DOVIZ_DEVIR { get; set; }
            public decimal KS_GELIR { get; set; }
            public decimal KS_DOVIZ_GELIR { get; set; }
            public decimal KS_GIDER { get; set; }
            public decimal KS_DOVIZ_GIDER { get; set; }
            public string KS_NOTLAR { get; set; }
        }
        public class RivaKasaHareket
        {
            public int KH_ID { get; set; }
            public int KH_ENTEGRA_TIP { get; set; }
            public int KH_ENTEGRA_ID { get; set; }
            public int KH_KASA_ID { get; set; }
            public DateTime KH_ISLEM_TARIHI { get; set; }
            public int KH_ISLEM_TIPI { get; set; }
            public int KH_GELIR_GIDER { get; set; }
            public string KH_EVRAK_NO { get; set; }
            public string KH_ACIKLAMA { get; set; }
            public decimal KH_DOVIZ_TUTAR { get; set; }
            public decimal KH_TUTAR { get; set; }
            public int KH_CARI_ID { get; set; }
            public int KH_PLASIYER_ID { get; set; }
        }
        public class RivaStokHareket
        {
            public int SH_ID { get; set; }
            public int SH_ENTEGRA_TIP { get; set; }
            public int SH_ENTEGRA_ID { get; set; }
            public int SH_STOK_ID { get; set; }
            public DateTime SH_ISLEM_TARIHI { get; set; }
            public string SH_ISLEM_TIPI { get; set; }
            public string SH_GIRIS_CIKIS { get; set; }
            public string SH_EVRAK_NO { get; set; }
            public string SH_ACIKLAMA { get; set; }
            public int SH_CARI_ID { get; set; }
            public int SH_DEPO_ID { get; set; }
            public int SH_PLASIYER_ID { get; set; }
            public string SH_OLCU_BIRIMI { get; set; }
            public decimal SH_MIKTAR { get; set; }
            public decimal SH_MIKTAR2 { get; set; }
            public int SH_DOVIZ_ID { get; set; }
            public decimal SH_DOVIZ_TUTAR { get; set; }
            public decimal SH_TUTAR { get; set; }
            public decimal SH_ISKONTO_TUTARI { get; set; }
            public decimal SH_KDV_TUTARI { get; set; }
            public decimal SH_MASRAF_TUTARI { get; set; }
            public string SK_ISIM { get; set; }
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cariler()
        {
            return View();
        }
        public IActionResult Faturalar()
        {
            return View();
        }
        #region SqlSorguları
        public string CultureInfoName = "en-US"; // "CultrueInfo" yerine düzeltilmiş
        public string ConverToString(decimal? value)
        {
            if (value == null)
                return string.Empty; // Eğer değer null ise boş string döndür

            return value.Value.ToString().Replace(",", ".");
        }


        public static T MapToEntity<T>(IDataReader reader) where T : new()
        {
            T obj = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                var columnName = prop.Name;
                if (HasColumn(reader, columnName) && !reader.IsDBNull(reader.GetOrdinal(columnName)))
                {
                    var value = reader.GetValue(reader.GetOrdinal(columnName));
                    try
                    {
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return obj;
        }
        public static bool HasColumn(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public long KasaHareketGir(string KasaId, string EvrakNo, decimal ToplamTutar, string CariId, string FaturaNo)
        {
            long insertedId = 0;
            string idQuery = $@"
                SELECT GEN_ID(GEN_KH_ID, 1) FROM RDB$DATABASE;
                ";
            var query = $@"
                INSERT INTO KASAHAREKET ( KH_ENTEGRA_TIP, KH_ENTEGRA_ID, KH_KASA_ID,
                    KH_ISLEM_TARIHI, KH_ISLEM_TIPI, KH_GELIR_GIDER, KH_EVRAK_NO, KH_ACIKLAMA,
                    KH_DOVIZ_TUTAR, KH_TUTAR, KH_CARI_ID, KH_PLASIYER_ID)
                VALUES (
                    '1095914566', 
                    {FaturaNo}, 
                    '{KasaId}', 
                    Date '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                    '-7', 
                    '0', 
                    '{EvrakNo}', 
                    'Faturamız (Peşinat)', 
                    '0', 
                    @ToplamTutar,
                    '{CariId}', 
                    null
                );
            ";
            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(idQuery, connection))
                {

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        insertedId = Convert.ToInt64(result);

                    }
                    else
                    {
                    }
                }
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    cmd.Parameters.Add("@ToplamTutar", ConverToString(ToplamTutar));
                    object result = cmd.ExecuteNonQuery();
                }
            }
            return insertedId;
        }
        public void StokHareketiGir(string CariHareketId, string StokId, string EvrakNo, string CariId, string OlçüBirimi, string Miktar, decimal Tutar)
        {
            var query = $@"
                INSERT INTO STOKHAREKET (SH_ENTEGRA_TIP, SH_ENTEGRA_ID, SH_STOK_ID,
                    SH_ISLEM_TARIHI, SH_ISLEM_TIPI, SH_GIRIS_CIKIS, SH_EVRAK_NO, SH_ACIKLAMA,
                    SH_CARI_ID, SH_DEPO_ID, SH_PLASIYER_ID, SH_OLCU_BIRIMI, SH_MIKTAR,
                    SH_MIKTAR2, SH_DOVIZ_ID, SH_DOVIZ_TUTAR, SH_TUTAR, SH_ISKONTO_TUTARI,
                    SH_KDV_TUTARI, SH_MASRAF_TUTARI)
                VALUES (
                    '1095914566', 
                    '{CariHareketId}', 
                    '{StokId}', 
                    Date '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                    '-5', 
                    '1', 
                    '{EvrakNo}', 
                    '{EvrakNo + "nolu Faturamız"} SıcakSatış', 
                    '{CariId}', 
                    '-1', 
                    null, 
                    {1}, 
                    '{Miktar}', 
                    '0', 
                    null, 
                    '0', 
                    @Tutar,
                    '0', 
                    '0', 
                    '0'
                    );
                    ";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    cmd.Parameters.Add("@Tutar", ConverToString(Tutar));
                    object result = cmd.ExecuteNonQuery();
                }
            }
        }
        public long CariHareketGir(string CariId, string FaturaId, string EvraNo, decimal GenelTutar, string İşlemTipi = null, string Açıklama = null, string EntagraId = null)
        {
            long insertedId = 0;
            string idQuery = $@"
                    SELECT GEN_ID(GEN_CH_ID, 1) FROM RDB$DATABASE;
                ";
            var query = $@"
                INSERT INTO CARIHAREKET ( CH_ENTEGRA_TIP, CH_ENTEGRA_ID, CH_CARI_ID,
                    CH_ISLEM_TARIHI, CH_ISLEM_TIPI, CH_EVRAK_NO, CH_ACIKLAMA, CH_VADE_TARIHI,
                    CH_PLASIYER_ID, CH_DOVIZ_ID, CH_DOVIZ_TUTAR, CH_TUTAR, CH_KAPATILMIS_TUTAR,
                    CH_EVRAK_TARIHI, CH_IBAN, CH_EFT_TIPI)
                VALUES (
                    '{(EntagraId == null ? "1095914566" : EntagraId)} ', 
                    '{FaturaId}', 
                    '{CariId}', 
                   DATE '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                    '{(İşlemTipi == null ? "-12" : İşlemTipi)}', 
                    '{EvraNo}', 
                    @Açıklama, 
                     DATE '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                    null, 
                    null, 
                    '0', 
                    @GenelTutar,
                    '0', 
                    null, 
                    null, 
                    '0'
                );
            ";
            //'{GenelTutar.Replace(",", ".")}', 

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(idQuery, connection))
                {

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        insertedId = Convert.ToInt64(result);
                    }
                    else
                    {
                    }
                }
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    cmd.Parameters.Add("@Açıklama", Açıklama);
                    cmd.Parameters.Add("@GenelTutar", ConverToString(GenelTutar));

                    object result = cmd.ExecuteNonQuery();
                }
            }
            return insertedId;
        }
        public long FaturaSatırGir(string FaturaId, string SıraNo, string StokId, string StokBaslık, string CariId, decimal Miktar, string OlcuBirimi, decimal SatırMaliyeti, string KdvOranı)
        {
            long insertedId = 0;
            string idQuery = $@"
                SELECT GEN_ID(GEN_FD_ID, 1) FROM RDB$DATABASE;
                ";
            string query = $@"
                INSERT INTO FATURADETAY ( FD_ENTEGRA_TIP, FD_ENTEGRA_ID, FD_FATURA_ID,
                    FD_SIRA_NO, FD_STOK_ID, FD_STOK_BASLIK, FD_CARI_ID, FD_DEPO_ID,
                    FD_PLASIYER_ID, FD_MIKTAR, FD_MIKTAR2, FD_OLCU_BIRIMI, FD_MAL_FAZLASI_ISK,
                    FD_DOVIZ_ID, FD_DOVIZ_TUTAR, FD_IADE_MALIYETI, FD_TUTAR, FD_KDV_ORANI,
                    FD_NAKLIYE_TUTARI, FD_TESLIM_TARIHI, FD_VADE_GUNU, FD_IRSALIYE_ID,
                    FD_IRSALIYE_DETAY_ID, FD_OTV_TUTAR, FD_MUHASEBE_ID, FD_SIPARIS_ID,
                    FD_SIPARIS_DETAY_ID, FD_SIPARIS_TAZMIN, FD_SIS_01, FD_SIS_02, FD_SIS_03)
                VALUES (
                    '0', 
                    null, 
                    '{FaturaId}', 
                    '{SıraNo}', 
                    '{StokId}', 
                    '{StokBaslık}', 
                    '{CariId}', 
                    '-1', 
                    null, 
                    @Miktar, 
                    '0', 
                    '{1}', 
                    '0', 
                    null, 
                    '0', 
                    '0', 

                    @Tutar,
                   


                    '{KdvOranı}', 
                    '0', 
                  date  '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                    '0', 
                    null, 
                    null, 
                    '0', 
                    null, 
                    null, 
                    null, 
                    '0', 
                    '0', 
                    '0', 
                    '0'
                );
                ";
            //'{SatırMaliyeti.ToString().Replace(".", "").Replace(",", ".")}', 
            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(idQuery, connection))
                {

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        insertedId = Convert.ToInt64(result);
                    }
                    else
                    {
                    }
                }
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Tutar", ConverToString(SatırMaliyeti));
                    cmd.Parameters.AddWithValue("Miktar", Miktar);
                    object result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            return insertedId;


        }
        public long FaturaGir(int CariId, decimal BrütToplam, long kalemSayısı, long toplamMiktar, decimal KdvToplam, string EvrakNo)
        {
            var cari = GetCari(CariId).FirstOrDefault();
            long insertedId = 0;
            string idQuery = $@"
                SELECT GEN_ID(GEN_FT_ID, 1) FROM RDB$DATABASE;
                ";

            string query = $@"
           INSERT INTO FATURA ( FT_EVRAK_TIPI, FT_EVRAK_NO, FT_CARI_ID, FT_UNVAN,
            FT_ADRES, FT_ILCE, FT_IL, FT_POSTA_KODU, FT_VERGI_DAIRESI,
            FT_VERGI_NUMARASI, FT_BABA_ADI, FT_DOGUM_YERI, FT_DOGUM_TARIHI,
            FT_BAGKUR_DAIRESI, FT_BAGKUR_NUMARASI, FT_TC_KIMLIK_NUMARASI, FT_ACIKLAMA,
            FT_TIP, FT_TARIH, FT_ZAMAN, FT_VADE_TARIHI, FT_KDV_VADE_TARIHI,
            FT_TESLIM_TARIHI, FT_LISTE_FIYATI, FT_DOVIZ_ID, FT_DOVIZ_KUR_TARIHI,
            FT_DOVIZ_TUTAR, FT_DEPO_ID, FT_PLASIYER_ID, FT_BRUT_TOPLAM,
            FT_MAL_FAZLASI_ISK, FT_SATIR_ISK_TOPLAMI, FT_GENEL_ISK_MATRAHI,
            FT_GENEL_ISK_TOPLAMI, FT_MUS_STOPAJ, FT_MUS_FON, FT_MUS_BORSA, FT_MUS_MERA,
            FT_MUS_BAGKUR, FT_MUS_KES_TOPLAMI, FT_KALEM_SAYISI, FT_TOPLAM_MIKTAR,
            FT_TOPLAM_AGIRLIK, FT_NAKLIYE_TUTARI, FT_NAKLIYE_TUTARI_KDV,
            FT_EK_MALIYET_TOPLAMI, FT_VADE_FARKI, FT_VADE_FARKI_KDV, FT_KDV_TOPLAMI,
            FT_KDV_TOPLAMI_YUV, FT_GENEL_TOPLAM, FT_GENEL_TOPLAM_YUV, FT_KDV_DAHIL,
            FT_KDV_ISK_ONCE_DUS, FT_KDV_MAL_FAZLASI, FT_KDV_MAL_FAZLA_NET,
            FT_CARIYE_KAYIT, FT_PESINAT_AYRILSIN, FT_STOKLARA_KAYIT, FT_STOK_IRS_TARIHI,
            FT_STOK_MAL_EK_MALIYET, FT_STOK_MAL_NAKLIYE, FT_KAPATILMIS, FT_KARSILANMIS,
            FT_NOTLAR, FT_SIS_01, FT_SIS_02, FT_SIS_03, FT_GIS_01, FT_GIS_02, FT_GIS_03,
            FT_EMT_01, FT_EMT_02, FT_EMT_03, FT_EMK_01, FT_EMK_02, FT_EMK_03)
            VALUES (
                '-1', 
                '{EvrakNo}', 
                '{CariId}', 
                '{cari.CA_UNVAN}', 
                '{cari.CA_ADRES}', 
                '{cari.CA_ILCE}', 
                '{cari.CA_IL}', 
                '{cari.CA_POSTA_KODU}', 
                '{cari.CA_VERGI_DAIRESI}', 
                '{cari.CA_VERGI_NUMARASI}', 
                '', 
                '', 
                null, 
                '', 
                '', 
                '', 
                'PERAKENDE SATIŞ', 
                '-4', 
                DATE '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                '44204', 
                DATE  '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                DATE  '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                DATE  '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                '', 
                null, 
                DATE   '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                '0', 
                '-1', 
                null, 
                @BürütToplam1, 
                '0', 
                '0', 
                @BürütToplam2, 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '{kalemSayısı}', 
                '{toplamMiktar}', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '18', 
                @KdvToplam1, 
                @KdvToplam2, 
                @BürütToplam3, 
                @BürütToplam4, 
                '0', 
                '0', 
                '0', 
                '0', 
                '1', 
                '0', 
                '1', 
                '0', 
                '0', 
                '1', 
                '0', 
                '0', 
                null, 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0', 
                '0'
                );
            ";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(idQuery, connection))
                {

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        insertedId = Convert.ToInt64(result);

                    }
                    else
                    {
                    }
                }
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    var brütToplam = ConverToString(BrütToplam);
                    var kdvToplam = ConverToString(KdvToplam);
                    cmd.Parameters.AddWithValue("@BürütToplam1", brütToplam);
                    cmd.Parameters.AddWithValue("@BürütToplam2", brütToplam);
                    cmd.Parameters.AddWithValue("@BürütToplam3", brütToplam);
                    cmd.Parameters.AddWithValue("@BürütToplam4", brütToplam);

                    cmd.Parameters.AddWithValue("@KdvToplam1", kdvToplam);
                    cmd.Parameters.AddWithValue("@KdvToplam2", kdvToplam);


                    object result = cmd.ExecuteNonQuery();
                }
            }
            return insertedId;

        }


        public string GetKasaHareketiLastEvrakNo()
        {

            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
                SELECT r.KH_EVRAK_NO
                    FROM KASAHAREKET r
                   order by r.KH_EVRAK_NO descending
                ";
            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<RivaKasaHareket>();

                        while (reader.Read())
                        {
                            RivaKasaHareket fatura = new RivaKasaHareket();

                            fatura.KH_EVRAK_NO = reader.IsDBNull(0) ? null : reader.GetString(0);

                            faturaBaslık.Add(fatura);
                        }
                        return (Convert.ToInt64(faturaBaslık.FirstOrDefault().KH_EVRAK_NO) + 1).ToString().PadLeft(10, '0');
                    }
                }
            }

        }
        public List<RivaKasa> GetKasa(string KasaKodu)
        {
            List<RivaKasa> stokList = new List<RivaKasa>();
            string query = $@"SELECT a.KS_ID, a.KS_KOD, a.KS_ISIM, a.KS_DOVIZ_ID, a.KS_MUHASEBE_ID,
                    a.KS_DEVIR_TARIHI, a.KS_DEVIR, a.KS_DOVIZ_DEVIR, a.KS_GELIR,
                    a.KS_DOVIZ_GELIR, a.KS_GIDER, a.KS_DOVIZ_GIDER, a.KS_NOTLAR
                FROM KASA a 
                WHERE
                    a.KS_KOD = '{KasaKodu}'";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                FbCommand command = new FbCommand(query, connection);
                connection.Open();

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaKasa>(reader);
                        stokList.Add(stok);
                    }
                }
            }
            return stokList;
        }
        public List<RivaStok> GetStokByBarkod(string Barkod)
        {
            var barkodList = Barkod.Split(" ");
            List<string> aramaString = new List<string>();

            foreach (var item in barkodList)
            {
                aramaString.Add($@" ( r.SK_OLCU1_BARKOD like '%{item}%' or r.SK_ISIM like '%{item}%' or r.SK_KOD like '%{item}%') ");
            }

            List<RivaStok> stokList = new List<RivaStok>();
            string query = $@"SELECT r.SK_ID, r.SK_KOD, r.SK_ISIM, r.SK_TIP, r.SK_URETICI_KODU,
                            r.SK_SATICI_ID, r.SK_DEPO_ID, r.SK_DOVIZ_ID, r.SK_FIRE_ID, r.SK_FIRE_ORANI,
                            r.SK_OLCU1_BIRIM, r.SK_OLCU2_BIRIM, r.SK_OLCU2_PAY, r.SK_OLCU2_PAYDA,
                            r.SK_OLCU3_BIRIM, r.SK_OLCU3_PAY, r.SK_OLCU3_PAYDA, r.SK_OLCU1_BARKOD,
                            r.SK_OLCU2_BARKOD, r.SK_OLCU3_BARKOD, r.SK_BIRIM_AGIRLIK,
                            r.SK_NAKLIYE_TUTARI, r.SK_ASGARI_LIMIT, r.SK_AZAMI_LIMIT, r.SK_RISK_SURESI,
                            r.SK_TEMIN_SURESI, r.SK_ALIS_KDV_ORANI, r.SK_SATIS_KDV_ORANI,
                            r.SK_ISKONTO_ORANI, r.SK_ASGARI_SIP_MIKTARI, r.SK_KULLANIM_MIKTARI,
                            r.SK_NITELIK_SABLON_ID, r.SK_SERI_TAKIBI, r.SK_OTO_SERI_GIRIS,
                            r.SK_OTO_SERI_CIKIS, r.SK_SERI_ONDEGER, r.SK_MIKTAR_KADAR_SERI,
                            r.SK_SERI_TEKRARSIZ, r.SK_LOT_TAKIBI, r.SK_OTO_LOT_GIRIS,
                            r.SK_OTO_LOT_CIKIS, r.SK_LOT_ONDEGER, r.SK_OTV_TIPI, r.SK_OTV_ORANI,
                            r.SK_GIRIS_MIKTARI, r.SK_CIKIS_MIKTARI, r.SK_GIRIS_TUTARI,
                            r.SK_CIKIS_TUTARI, r.SK_MUS_SIPARIS_MIKTAR, r.SK_MUS_SIPARIS_TAZMIN,
                            r.SK_SAT_SIPARIS_MIKTAR, r.SK_SAT_SIPARIS_TAZMIN, r.SK_KILIT,
                            r.SK_MSB_DETAY_ID, r.SK_NOTLAR, r.SK_OZK_GRUP_KODU, r.SK_OZK_MARKA_KODU,
                            r.SK_OZK_TIP_KODU, r.SK_ALF_A, r.SK_ALF_B, r.SK_ALF_C, r.SK_STF_A,
                            r.SK_STF_B, r.SK_STF_C, r.SK_DAF_A, r.SK_DAF_B, r.SK_DAF_C, r.SK_DSF_A,
                            r.SK_DSF_B, r.SK_DSF_C, r.SK_MID_01, r.SK_MID_02, r.SK_MID_03, r.SK_MID_04,
                            r.SK_MID_05, r.SK_MID_06, r.SK_MID_07
                        FROM STOK r {(aramaString.Count() >= 1 ? ("where " + string.Join(" and ", aramaString)) : "")}";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                FbCommand command = new FbCommand(query, connection);
                connection.Open();

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaStok>(reader);
                        stokList.Add(stok);
                    }
                }
            }
            return stokList;
        }
        public List<RivaStok> GetStokById(string Id)
        {
            List<RivaStok> stokList = new List<RivaStok>();
            string query = $@"SELECT r.SK_ID, r.SK_KOD, r.SK_ISIM, r.SK_TIP, r.SK_URETICI_KODU,
                            r.SK_SATICI_ID, r.SK_DEPO_ID, r.SK_DOVIZ_ID, r.SK_FIRE_ID, r.SK_FIRE_ORANI,
                            r.SK_OLCU1_BIRIM, r.SK_OLCU2_BIRIM, r.SK_OLCU2_PAY, r.SK_OLCU2_PAYDA,
                            r.SK_OLCU3_BIRIM, r.SK_OLCU3_PAY, r.SK_OLCU3_PAYDA, r.SK_OLCU1_BARKOD,
                            r.SK_OLCU2_BARKOD, r.SK_OLCU3_BARKOD, r.SK_BIRIM_AGIRLIK,
                            r.SK_NAKLIYE_TUTARI, r.SK_ASGARI_LIMIT, r.SK_AZAMI_LIMIT, r.SK_RISK_SURESI,
                            r.SK_TEMIN_SURESI, r.SK_ALIS_KDV_ORANI, r.SK_SATIS_KDV_ORANI,
                            r.SK_ISKONTO_ORANI, r.SK_ASGARI_SIP_MIKTARI, r.SK_KULLANIM_MIKTARI,
                            r.SK_NITELIK_SABLON_ID, r.SK_SERI_TAKIBI, r.SK_OTO_SERI_GIRIS,
                            r.SK_OTO_SERI_CIKIS, r.SK_SERI_ONDEGER, r.SK_MIKTAR_KADAR_SERI,
                            r.SK_SERI_TEKRARSIZ, r.SK_LOT_TAKIBI, r.SK_OTO_LOT_GIRIS,
                            r.SK_OTO_LOT_CIKIS, r.SK_LOT_ONDEGER, r.SK_OTV_TIPI, r.SK_OTV_ORANI,
                            r.SK_GIRIS_MIKTARI, r.SK_CIKIS_MIKTARI, r.SK_GIRIS_TUTARI,
                            r.SK_CIKIS_TUTARI, r.SK_MUS_SIPARIS_MIKTAR, r.SK_MUS_SIPARIS_TAZMIN,
                            r.SK_SAT_SIPARIS_MIKTAR, r.SK_SAT_SIPARIS_TAZMIN, r.SK_KILIT,
                            r.SK_MSB_DETAY_ID, r.SK_NOTLAR, r.SK_OZK_GRUP_KODU, r.SK_OZK_MARKA_KODU,
                            r.SK_OZK_TIP_KODU, r.SK_ALF_A, r.SK_ALF_B, r.SK_ALF_C, r.SK_STF_A,
                            r.SK_STF_B, r.SK_STF_C, r.SK_DAF_A, r.SK_DAF_B, r.SK_DAF_C, r.SK_DSF_A,
                            r.SK_DSF_B, r.SK_DSF_C, r.SK_MID_01, r.SK_MID_02, r.SK_MID_03, r.SK_MID_04,
                            r.SK_MID_05, r.SK_MID_06, r.SK_MID_07
                        FROM STOK r where r.SK_ID = '{Id}'";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                FbCommand command = new FbCommand(query, connection);
                connection.Open();

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaStok>(reader);
                        stokList.Add(stok);
                    }
                }
            }
            return stokList;
        }
        public List<RivaStok> GetAllStokInfınıty(string StokKodu, string StokAdı, int pageNumber)
        {
            int pageSize = 10; // Sayfa boyutu
            int offset = (pageNumber - 1) * pageSize; // Atlanacak kayıt sayısını hesapla
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            List<RivaStok> stokList = new List<RivaStok>();
            string query = $@"SELECT FIRST @PageSize SKIP @Offset r.SK_ID, r.SK_KOD, r.SK_ISIM, r.SK_TIP, r.SK_URETICI_KODU,
                            r.SK_SATICI_ID, r.SK_DEPO_ID, r.SK_DOVIZ_ID, r.SK_FIRE_ID, r.SK_FIRE_ORANI,
                            r.SK_OLCU1_BIRIM, r.SK_OLCU2_BIRIM, r.SK_OLCU2_PAY, r.SK_OLCU2_PAYDA,
                            r.SK_OLCU3_BIRIM, r.SK_OLCU3_PAY, r.SK_OLCU3_PAYDA, r.SK_OLCU1_BARKOD,
                            r.SK_OLCU2_BARKOD, r.SK_OLCU3_BARKOD, r.SK_BIRIM_AGIRLIK,
                            r.SK_NAKLIYE_TUTARI, r.SK_ASGARI_LIMIT, r.SK_AZAMI_LIMIT, r.SK_RISK_SURESI,
                            r.SK_TEMIN_SURESI, r.SK_ALIS_KDV_ORANI, r.SK_SATIS_KDV_ORANI,
                            r.SK_ISKONTO_ORANI, r.SK_ASGARI_SIP_MIKTARI, r.SK_KULLANIM_MIKTARI,
                            r.SK_NITELIK_SABLON_ID, r.SK_SERI_TAKIBI, r.SK_OTO_SERI_GIRIS,
                            r.SK_OTO_SERI_CIKIS, r.SK_SERI_ONDEGER, r.SK_MIKTAR_KADAR_SERI,
                            r.SK_SERI_TEKRARSIZ, r.SK_LOT_TAKIBI, r.SK_OTO_LOT_GIRIS,
                            r.SK_OTO_LOT_CIKIS, r.SK_LOT_ONDEGER, r.SK_OTV_TIPI, r.SK_OTV_ORANI,
                            r.SK_GIRIS_MIKTARI, r.SK_CIKIS_MIKTARI, r.SK_GIRIS_TUTARI,
                            r.SK_CIKIS_TUTARI, r.SK_MUS_SIPARIS_MIKTAR, r.SK_MUS_SIPARIS_TAZMIN,
                            r.SK_SAT_SIPARIS_MIKTAR, r.SK_SAT_SIPARIS_TAZMIN, r.SK_KILIT,
                            r.SK_MSB_DETAY_ID, r.SK_NOTLAR, r.SK_OZK_GRUP_KODU, r.SK_OZK_MARKA_KODU,
                            r.SK_OZK_TIP_KODU, r.SK_ALF_A, r.SK_ALF_B, r.SK_ALF_C, r.SK_STF_A,
                            r.SK_STF_B, r.SK_STF_C, r.SK_DAF_A, r.SK_DAF_B, r.SK_DAF_C, r.SK_DSF_A,
                            r.SK_DSF_B, r.SK_DSF_C, r.SK_MID_01, r.SK_MID_02, r.SK_MID_03, r.SK_MID_04,
                            r.SK_MID_05, r.SK_MID_06, r.SK_MID_07
                        FROM STOK r

            where r.SK_KOD like '%{StokKodu}%' and r.SK_ISIM like '%{StokAdı}%'

";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                FbCommand command = new FbCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@Offset", offset);
                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaStok>(reader);
                        stokList.Add(stok);
                    }
                }
            }
            return stokList;
        }
        public List<RivaStok> GetAllStok()
        {
            List<RivaStok> stokList = new List<RivaStok>();
            string query = @"SELECT r.SK_ID, r.SK_KOD, r.SK_ISIM, r.SK_TIP, r.SK_URETICI_KODU,
                            r.SK_SATICI_ID, r.SK_DEPO_ID, r.SK_DOVIZ_ID, r.SK_FIRE_ID, r.SK_FIRE_ORANI,
                            r.SK_OLCU1_BIRIM, r.SK_OLCU2_BIRIM, r.SK_OLCU2_PAY, r.SK_OLCU2_PAYDA,
                            r.SK_OLCU3_BIRIM, r.SK_OLCU3_PAY, r.SK_OLCU3_PAYDA, r.SK_OLCU1_BARKOD,
                            r.SK_OLCU2_BARKOD, r.SK_OLCU3_BARKOD, r.SK_BIRIM_AGIRLIK,
                            r.SK_NAKLIYE_TUTARI, r.SK_ASGARI_LIMIT, r.SK_AZAMI_LIMIT, r.SK_RISK_SURESI,
                            r.SK_TEMIN_SURESI, r.SK_ALIS_KDV_ORANI, r.SK_SATIS_KDV_ORANI,
                            r.SK_ISKONTO_ORANI, r.SK_ASGARI_SIP_MIKTARI, r.SK_KULLANIM_MIKTARI,
                            r.SK_NITELIK_SABLON_ID, r.SK_SERI_TAKIBI, r.SK_OTO_SERI_GIRIS,
                            r.SK_OTO_SERI_CIKIS, r.SK_SERI_ONDEGER, r.SK_MIKTAR_KADAR_SERI,
                            r.SK_SERI_TEKRARSIZ, r.SK_LOT_TAKIBI, r.SK_OTO_LOT_GIRIS,
                            r.SK_OTO_LOT_CIKIS, r.SK_LOT_ONDEGER, r.SK_OTV_TIPI, r.SK_OTV_ORANI,
                            r.SK_GIRIS_MIKTARI, r.SK_CIKIS_MIKTARI, r.SK_GIRIS_TUTARI,
                            r.SK_CIKIS_TUTARI, r.SK_MUS_SIPARIS_MIKTAR, r.SK_MUS_SIPARIS_TAZMIN,
                            r.SK_SAT_SIPARIS_MIKTAR, r.SK_SAT_SIPARIS_TAZMIN, r.SK_KILIT,
                            r.SK_MSB_DETAY_ID, r.SK_NOTLAR, r.SK_OZK_GRUP_KODU, r.SK_OZK_MARKA_KODU,
                            r.SK_OZK_TIP_KODU, r.SK_ALF_A, r.SK_ALF_B, r.SK_ALF_C, r.SK_STF_A,
                            r.SK_STF_B, r.SK_STF_C, r.SK_DAF_A, r.SK_DAF_B, r.SK_DAF_C, r.SK_DSF_A,
                            r.SK_DSF_B, r.SK_DSF_C, r.SK_MID_01, r.SK_MID_02, r.SK_MID_03, r.SK_MID_04,
                            r.SK_MID_05, r.SK_MID_06, r.SK_MID_07
                        FROM STOK r";

            using (FbConnection connection = new FbConnection(_connectionString))
            {
                FbCommand command = new FbCommand(query, connection);
                connection.Open();

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaStok>(reader);
                        stokList.Add(stok);
                    }
                }
            }
            return stokList;
        }
        public List<FaturaDetayDto> GetFaturaDetayByFaturaId(string FaturaId)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
                  SELECT r.FD_ID, r.FD_ENTEGRA_TIP, r.FD_ENTEGRA_ID, r.FD_FATURA_ID, r.FD_SIRA_NO,
                    r.FD_STOK_ID, r.FD_STOK_BASLIK, r.FD_CARI_ID, r.FD_DEPO_ID,
                    r.FD_PLASIYER_ID, r.FD_MIKTAR, r.FD_MIKTAR2, r.FD_OLCU_BIRIMI,
                    r.FD_MAL_FAZLASI_ISK, r.FD_DOVIZ_ID, r.FD_DOVIZ_TUTAR, r.FD_IADE_MALIYETI,
                    r.FD_TUTAR, r.FD_KDV_ORANI, r.FD_NAKLIYE_TUTARI, r.FD_TESLIM_TARIHI,
                    r.FD_VADE_GUNU, r.FD_IRSALIYE_ID, r.FD_IRSALIYE_DETAY_ID, r.FD_OTV_TUTAR,
                    r.FD_MUHASEBE_ID, r.FD_SIPARIS_ID, r.FD_SIPARIS_DETAY_ID,
                    r.FD_SIPARIS_TAZMIN, r.FD_SIS_01, r.FD_SIS_02, r.FD_SIS_03
                    FROM FATURADETAY r where r.FD_FATURA_ID = '{FaturaId}'";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var faturaBaslık = new List<FaturaDetayDto>();
                    while (reader.Read())
                    {
                        var stok = MapToEntity<FaturaDetayDto>(reader);
                        faturaBaslık.Add(stok);
                    }
                    return faturaBaslık;
                }
            }
        }

        public List<FaturaDetayDto> GetFaturaDetayByMulFaturaId(string[] FaturaId)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
                  SELECT r.FD_ID, r.FD_ENTEGRA_TIP, r.FD_ENTEGRA_ID, r.FD_FATURA_ID, r.FD_SIRA_NO,
                    r.FD_STOK_ID, r.FD_STOK_BASLIK, r.FD_CARI_ID, r.FD_DEPO_ID,
                    r.FD_PLASIYER_ID, r.FD_MIKTAR, r.FD_MIKTAR2, r.FD_OLCU_BIRIMI,
                    r.FD_MAL_FAZLASI_ISK, r.FD_DOVIZ_ID, r.FD_DOVIZ_TUTAR, r.FD_IADE_MALIYETI,
                    r.FD_TUTAR, r.FD_KDV_ORANI, r.FD_NAKLIYE_TUTARI, r.FD_TESLIM_TARIHI,
                    r.FD_VADE_GUNU, r.FD_IRSALIYE_ID, r.FD_IRSALIYE_DETAY_ID, r.FD_OTV_TUTAR,
                    r.FD_MUHASEBE_ID, r.FD_SIPARIS_ID, r.FD_SIPARIS_DETAY_ID,
                    r.FD_SIPARIS_TAZMIN, r.FD_SIS_01, r.FD_SIS_02, r.FD_SIS_03
                    FROM FATURADETAY r where r.FD_FATURA_ID in ('{string.Join("','", FaturaId)}') ";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var faturaBaslık = new List<FaturaDetayDto>();
                    while (reader.Read())
                    {
                        var stok = MapToEntity<FaturaDetayDto>(reader);
                        faturaBaslık.Add(stok);
                    }
                    return faturaBaslık;
                }
            }
        }
        public List<FaturaDto> GetFaturaBaşlıkByEvrakNo(string EvrakNo)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
                SELECT r.FT_ID, r.FT_EVRAK_TIPI, r.FT_EVRAK_NO, r.FT_CARI_ID, r.FT_UNVAN,
                r.FT_ADRES, r.FT_ILCE, r.FT_IL, r.FT_POSTA_KODU, r.FT_VERGI_DAIRESI,
                r.FT_VERGI_NUMARASI, r.FT_BABA_ADI, r.FT_DOGUM_YERI, r.FT_DOGUM_TARIHI,
                r.FT_BAGKUR_DAIRESI, r.FT_BAGKUR_NUMARASI, r.FT_TC_KIMLIK_NUMARASI,
                r.FT_ACIKLAMA, r.FT_TIP, r.FT_TARIH, r.FT_ZAMAN, r.FT_VADE_TARIHI,
                r.FT_KDV_VADE_TARIHI, r.FT_TESLIM_TARIHI, r.FT_LISTE_FIYATI, r.FT_DOVIZ_ID,
                r.FT_DOVIZ_KUR_TARIHI, r.FT_DOVIZ_TUTAR, r.FT_DEPO_ID, r.FT_PLASIYER_ID,
                r.FT_BRUT_TOPLAM, r.FT_MAL_FAZLASI_ISK, r.FT_SATIR_ISK_TOPLAMI,
                r.FT_GENEL_ISK_MATRAHI, r.FT_GENEL_ISK_TOPLAMI, r.FT_MUS_STOPAJ,
                r.FT_MUS_FON, r.FT_MUS_BORSA, r.FT_MUS_MERA, r.FT_MUS_BAGKUR,
                r.FT_MUS_KES_TOPLAMI, r.FT_KALEM_SAYISI, r.FT_TOPLAM_MIKTAR,
                r.FT_TOPLAM_AGIRLIK, r.FT_NAKLIYE_TUTARI, r.FT_NAKLIYE_TUTARI_KDV,
                r.FT_EK_MALIYET_TOPLAMI, r.FT_VADE_FARKI, r.FT_VADE_FARKI_KDV,
                r.FT_KDV_TOPLAMI, r.FT_KDV_TOPLAMI_YUV, r.FT_GENEL_TOPLAM,
                r.FT_GENEL_TOPLAM_YUV, r.FT_KDV_DAHIL, r.FT_KDV_ISK_ONCE_DUS,
                r.FT_KDV_MAL_FAZLASI, r.FT_KDV_MAL_FAZLA_NET, r.FT_CARIYE_KAYIT,
                r.FT_PESINAT_AYRILSIN, r.FT_STOKLARA_KAYIT, r.FT_STOK_IRS_TARIHI,
                r.FT_STOK_MAL_EK_MALIYET, r.FT_STOK_MAL_NAKLIYE, r.FT_KAPATILMIS,
                r.FT_KARSILANMIS, r.FT_NOTLAR, r.FT_SIS_01, r.FT_SIS_02, r.FT_SIS_03,
                r.FT_GIS_01, r.FT_GIS_02, r.FT_GIS_03, r.FT_EMT_01, r.FT_EMT_02,
                r.FT_EMT_03, r.FT_EMK_01, r.FT_EMK_02, r.FT_EMK_03
                FROM FATURA r where r.FT_EVRAK_NO = '{EvrakNo}'";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var faturaBaslık = new List<FaturaDto>();

                    while (reader.Read())
                    {
                        var stok = MapToEntity<FaturaDto>(reader);
                        faturaBaslık.Add(stok);
                    }
                    return faturaBaslık;
                }
            }
        }
        public List<FaturaDto> GetFaturalar()
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
                SELECT r.FT_ID, r.FT_EVRAK_TIPI, r.FT_EVRAK_NO, r.FT_CARI_ID, r.FT_UNVAN,
                r.FT_ADRES, r.FT_ILCE, r.FT_IL, r.FT_POSTA_KODU, r.FT_VERGI_DAIRESI,
                r.FT_VERGI_NUMARASI, r.FT_BABA_ADI, r.FT_DOGUM_YERI, r.FT_DOGUM_TARIHI,
                r.FT_BAGKUR_DAIRESI, r.FT_BAGKUR_NUMARASI, r.FT_TC_KIMLIK_NUMARASI,
                r.FT_ACIKLAMA, r.FT_TIP, r.FT_TARIH, r.FT_ZAMAN, r.FT_VADE_TARIHI,
                r.FT_KDV_VADE_TARIHI, r.FT_TESLIM_TARIHI, r.FT_LISTE_FIYATI, r.FT_DOVIZ_ID,
                r.FT_DOVIZ_KUR_TARIHI, r.FT_DOVIZ_TUTAR, r.FT_DEPO_ID, r.FT_PLASIYER_ID,
                r.FT_BRUT_TOPLAM, r.FT_MAL_FAZLASI_ISK, r.FT_SATIR_ISK_TOPLAMI,
                r.FT_GENEL_ISK_MATRAHI, r.FT_GENEL_ISK_TOPLAMI, r.FT_MUS_STOPAJ,
                r.FT_MUS_FON, r.FT_MUS_BORSA, r.FT_MUS_MERA, r.FT_MUS_BAGKUR,
                r.FT_MUS_KES_TOPLAMI, r.FT_KALEM_SAYISI, r.FT_TOPLAM_MIKTAR,
                r.FT_TOPLAM_AGIRLIK, r.FT_NAKLIYE_TUTARI, r.FT_NAKLIYE_TUTARI_KDV,
                r.FT_EK_MALIYET_TOPLAMI, r.FT_VADE_FARKI, r.FT_VADE_FARKI_KDV,
                r.FT_KDV_TOPLAMI, r.FT_KDV_TOPLAMI_YUV, r.FT_GENEL_TOPLAM,
                r.FT_GENEL_TOPLAM_YUV, r.FT_KDV_DAHIL, r.FT_KDV_ISK_ONCE_DUS,
                r.FT_KDV_MAL_FAZLASI, r.FT_KDV_MAL_FAZLA_NET, r.FT_CARIYE_KAYIT,
                r.FT_PESINAT_AYRILSIN, r.FT_STOKLARA_KAYIT, r.FT_STOK_IRS_TARIHI,
                r.FT_STOK_MAL_EK_MALIYET, r.FT_STOK_MAL_NAKLIYE, r.FT_KAPATILMIS,
                r.FT_KARSILANMIS, r.FT_NOTLAR, r.FT_SIS_01, r.FT_SIS_02, r.FT_SIS_03,
                r.FT_GIS_01, r.FT_GIS_02, r.FT_GIS_03, r.FT_EMT_01, r.FT_EMT_02,
                r.FT_EMT_03, r.FT_EMK_01, r.FT_EMK_02, r.FT_EMK_03
                FROM FATURA r";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var faturaBaslık = new List<FaturaDto>();

                    while (reader.Read())
                    {
                        var stok = MapToEntity<FaturaDto>(reader);
                        faturaBaslık.Add(stok);
                    }
                    return faturaBaslık;
                }
            }
        }
        public List<RivaFatura> GetFaturalarByCariId(int CariId)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
                SELECT r.FT_ID, r.FT_EVRAK_TIPI, r.FT_EVRAK_NO, r.FT_CARI_ID, r.FT_UNVAN,
                r.FT_ADRES, r.FT_ILCE, r.FT_IL, r.FT_POSTA_KODU, r.FT_VERGI_DAIRESI,
                r.FT_VERGI_NUMARASI, r.FT_BABA_ADI, r.FT_DOGUM_YERI, r.FT_DOGUM_TARIHI,
                r.FT_BAGKUR_DAIRESI, r.FT_BAGKUR_NUMARASI, r.FT_TC_KIMLIK_NUMARASI,
                r.FT_ACIKLAMA, r.FT_TIP, r.FT_TARIH, r.FT_ZAMAN, r.FT_VADE_TARIHI,
                r.FT_KDV_VADE_TARIHI, r.FT_TESLIM_TARIHI, r.FT_LISTE_FIYATI, r.FT_DOVIZ_ID,
                r.FT_DOVIZ_KUR_TARIHI, r.FT_DOVIZ_TUTAR, r.FT_DEPO_ID, r.FT_PLASIYER_ID,
                r.FT_BRUT_TOPLAM, r.FT_MAL_FAZLASI_ISK, r.FT_SATIR_ISK_TOPLAMI,
                r.FT_GENEL_ISK_MATRAHI, r.FT_GENEL_ISK_TOPLAMI, r.FT_MUS_STOPAJ,
                r.FT_MUS_FON, r.FT_MUS_BORSA, r.FT_MUS_MERA, r.FT_MUS_BAGKUR,
                r.FT_MUS_KES_TOPLAMI, r.FT_KALEM_SAYISI, r.FT_TOPLAM_MIKTAR,
                r.FT_TOPLAM_AGIRLIK, r.FT_NAKLIYE_TUTARI, r.FT_NAKLIYE_TUTARI_KDV,
                r.FT_EK_MALIYET_TOPLAMI, r.FT_VADE_FARKI, r.FT_VADE_FARKI_KDV,
                r.FT_KDV_TOPLAMI, r.FT_KDV_TOPLAMI_YUV, r.FT_GENEL_TOPLAM,
                r.FT_GENEL_TOPLAM_YUV, r.FT_KDV_DAHIL, r.FT_KDV_ISK_ONCE_DUS,
                r.FT_KDV_MAL_FAZLASI, r.FT_KDV_MAL_FAZLA_NET, r.FT_CARIYE_KAYIT,
                r.FT_PESINAT_AYRILSIN, r.FT_STOKLARA_KAYIT, r.FT_STOK_IRS_TARIHI,
                r.FT_STOK_MAL_EK_MALIYET, r.FT_STOK_MAL_NAKLIYE, r.FT_KAPATILMIS,
                r.FT_KARSILANMIS, r.FT_NOTLAR, r.FT_SIS_01, r.FT_SIS_02, r.FT_SIS_03,
                r.FT_GIS_01, r.FT_GIS_02, r.FT_GIS_03, r.FT_EMT_01, r.FT_EMT_02,
                r.FT_EMT_03, r.FT_EMK_01, r.FT_EMK_02, r.FT_EMK_03
                FROM FATURA r where r.FT_CARI_ID = {CariId}";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var faturaBaslık = new List<RivaFatura>();

                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaFatura>(reader);
                        faturaBaslık.Add(stok);
                    }
                    return faturaBaslık;
                }
            }
        }
        public List<RivaCariHareket> GetCariHareket(int CariId)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
        SELECT r.CH_ID, r.CH_ENTEGRA_TIP, r.CH_ENTEGRA_ID, r.CH_CARI_ID,
               r.CH_ISLEM_TARIHI, r.CH_ISLEM_TIPI, r.CH_EVRAK_NO, r.CH_ACIKLAMA,
               r.CH_VADE_TARIHI, r.CH_PLASIYER_ID, r.CH_DOVIZ_ID, r.CH_DOVIZ_TUTAR,
               r.CH_TUTAR, r.CH_KAPATILMIS_TUTAR, r.CH_EVRAK_TARIHI, r.CH_IBAN,
               r.CH_EFT_TIPI
        FROM CARIHAREKET r  where r.CH_CARI_ID = '{CariId}'";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var cariHareketList = new List<RivaCariHareket>();

                    while (reader.Read())
                    {
                        cariHareketList.Add(new RivaCariHareket
                        {
                            CH_ID = reader.GetInt32(0),
                            CH_ENTEGRA_TIP = reader.IsDBNull(1) ? null : reader.GetString(1),
                            CH_ENTEGRA_ID = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                            CH_CARI_ID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            CH_ISLEM_TARIHI = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            CH_ISLEM_TIPI = reader.IsDBNull(5) ? null : reader.GetString(5),
                            CH_EVRAK_NO = reader.IsDBNull(6) ? null : reader.GetString(6),
                            CH_ACIKLAMA = reader.IsDBNull(7) ? null : reader.GetString(7),
                            CH_VADE_TARIHI = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                            CH_PLASIYER_ID = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                            CH_DOVIZ_ID = reader.IsDBNull(10) ? (int?)null : reader.GetInt32(10),
                            CH_DOVIZ_TUTAR = reader.IsDBNull(11) ? (decimal?)null : reader.GetDecimal(11),
                            CH_TUTAR = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12),
                            CH_KAPATILMIS_TUTAR = reader.IsDBNull(13) ? (decimal?)null : reader.GetDecimal(13),
                            CH_EVRAK_TARIHI = reader.IsDBNull(14) ? (DateTime?)null : reader.GetDateTime(14),
                            CH_IBAN = reader.IsDBNull(15) ? null : reader.GetString(15),
                            CH_EFT_TIPI = reader.IsDBNull(16) ? null : reader.GetString(16)
                        });
                    }
                    return cariHareketList;
                    // Verileri işle
                }
            }
        }
        public List<RivaCariHareket> GetCariHareketInfınıty(int pageNumber, int CariId, DateTime StartDate, DateTime EndDate)
        {

            int pageSize = 10; // Sayfa boyutu
            int offset = (pageNumber - 1) * pageSize; // Atlanacak kayıt sayısını hesapla

            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@" 
        SELECT FIRST @PageSize SKIP @Offset r.CH_ID, r.CH_ENTEGRA_TIP, r.CH_ENTEGRA_ID, r.CH_CARI_ID,
               r.CH_ISLEM_TARIHI, r.CH_ISLEM_TIPI, r.CH_EVRAK_NO, r.CH_ACIKLAMA,
               r.CH_VADE_TARIHI, r.CH_PLASIYER_ID, r.CH_DOVIZ_ID, r.CH_DOVIZ_TUTAR,
               r.CH_TUTAR, r.CH_KAPATILMIS_TUTAR, r.CH_EVRAK_TARIHI, r.CH_IBAN,
               r.CH_EFT_TIPI
        FROM CARIHAREKET r  where 
r.CH_CARI_ID = '{CariId}'              AND r.CH_ISLEM_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi       ";

                using (var command = new FbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@BaslangicTarihi", StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@BitisTarihi", EndDate.ToString("yyyy-MM-dd"));
                    using (var reader = command.ExecuteReader())
                    {
                        var cariHareketList = new List<RivaCariHareket>();

                        while (reader.Read())
                        {
                            cariHareketList.Add(new RivaCariHareket
                            {
                                CH_ID = reader.GetInt32(0),
                                CH_ENTEGRA_TIP = reader.IsDBNull(1) ? null : reader.GetString(1),
                                CH_ENTEGRA_ID = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                CH_CARI_ID = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                                CH_ISLEM_TARIHI = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                CH_ISLEM_TIPI = reader.IsDBNull(5) ? null : reader.GetString(5),
                                CH_EVRAK_NO = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CH_ACIKLAMA = reader.IsDBNull(7) ? null : reader.GetString(7),
                                CH_VADE_TARIHI = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                CH_PLASIYER_ID = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                                CH_DOVIZ_ID = reader.IsDBNull(10) ? (int?)null : reader.GetInt32(10),
                                CH_DOVIZ_TUTAR = reader.IsDBNull(11) ? (decimal?)null : reader.GetDecimal(11),
                                CH_TUTAR = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12),
                                CH_KAPATILMIS_TUTAR = reader.IsDBNull(13) ? (decimal?)null : reader.GetDecimal(13),
                                CH_EVRAK_TARIHI = reader.IsDBNull(14) ? (DateTime?)null : reader.GetDateTime(14),
                                CH_IBAN = reader.IsDBNull(15) ? null : reader.GetString(15),
                                CH_EFT_TIPI = reader.IsDBNull(16) ? null : reader.GetString(16)
                            });
                        }
                        return cariHareketList;
                        // Verileri işle
                    }
                }

            }
        }
        public List<RivaCari> GetCari(string CariKodu)
        {
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
         SELECT 
            r.CA_ID, r.CA_KOD, r.CA_UNVAN, r.CA_CARI_TIP_ID, r.CA_ADRES, r.CA_ILCE,
            r.CA_IL, r.CA_POSTA_KODU, r.CA_VERGI_DAIRESI, r.CA_VERGI_NUMARASI,
            r.CA_ULKE_ID, r.CA_TC_KIMLIK_NO, r.CA_MUHASEBE_ID, r.CA_PLASIYER_ID,
            r.CA_LISTE_FIYATI, r.CA_DOVIZ_ID, r.CA_ISKONTO_ORANI,
            r.CA_NAKLIYE_KATSAYISI, r.CA_ODEME_GUNU, r.CA_VADE_GUNU,
            r.CA_MUTABAKAT_TARIHI, r.CA_MUTABAKAT_BAKIYE, r.CA_MUT_MEKTUP_TARIHI,
            r.CA_MUT_MEKTUP_BAKIYE, r.CA_RISK_LIMITI, r.CA_TEMINAT_TUTARI,
            r.CA_CEK_ASIL_RISKI, r.CA_CEK_CIRO_RISKI, r.CA_SENET_ASIL_RISKI,
            r.CA_SENET_CIRO_RISKI, r.CA_BORC, r.CA_ALACAK, r.CA_NOTLAR,
            r.CA_KTA_BOLGE_KODU, r.CA_KTA_GRUP_KODU, r.CA_KTA_OZEL_KOD, r.CA_TLF_CEP,
            r.CA_TLF_FAKS, r.CA_TLF_TELEFON
        FROM CARI r 

 WHERE 
          r.CA_KOD = '{CariKodu}'

        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RivaCari cari = new RivaCari();
                            cari.CA_ID = reader.IsDBNull(reader.GetOrdinal("CA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ID"));
                            cari.CA_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KOD"));
                            cari.CA_UNVAN = reader.IsDBNull(reader.GetOrdinal("CA_UNVAN")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_UNVAN"));
                            cari.CA_CARI_TIP_ID = reader.IsDBNull(reader.GetOrdinal("CA_CARI_TIP_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_CARI_TIP_ID"));
                            cari.CA_ADRES = reader.IsDBNull(reader.GetOrdinal("CA_ADRES")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ADRES"));
                            cari.CA_ILCE = reader.IsDBNull(reader.GetOrdinal("CA_ILCE")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ILCE"));
                            cari.CA_IL = reader.IsDBNull(reader.GetOrdinal("CA_IL")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_IL"));
                            cari.CA_POSTA_KODU = reader.IsDBNull(reader.GetOrdinal("CA_POSTA_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_POSTA_KODU"));
                            cari.CA_VERGI_DAIRESI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_DAIRESI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_DAIRESI"));
                            cari.CA_VERGI_NUMARASI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_NUMARASI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_NUMARASI"));
                            cari.CA_ULKE_ID = reader.IsDBNull(reader.GetOrdinal("CA_ULKE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ULKE_ID"));
                            cari.CA_TC_KIMLIK_NO = reader.IsDBNull(reader.GetOrdinal("CA_TC_KIMLIK_NO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TC_KIMLIK_NO"));
                            cari.CA_MUHASEBE_ID = reader.IsDBNull(reader.GetOrdinal("CA_MUHASEBE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_MUHASEBE_ID"));
                            cari.CA_PLASIYER_ID = reader.IsDBNull(reader.GetOrdinal("CA_PLASIYER_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_PLASIYER_ID"));
                            //cari.CA_LISTE_FIYATI = reader.IsDBNull(reader.GetOrdinal("CA_LISTE_FIYATI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_LISTE_FIYATI"));
                            cari.CA_DOVIZ_ID = reader.IsDBNull(reader.GetOrdinal("CA_DOVIZ_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_DOVIZ_ID"));
                            cari.CA_ISKONTO_ORANI = reader.IsDBNull(reader.GetOrdinal("CA_ISKONTO_ORANI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ISKONTO_ORANI"));
                            cari.CA_NAKLIYE_KATSAYISI = reader.IsDBNull(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI"));
                            cari.CA_ODEME_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_ODEME_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ODEME_GUNU"));
                            cari.CA_VADE_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_VADE_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_VADE_GUNU"));
                            cari.CA_MUTABAKAT_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUTABAKAT_TARIHI"));
                            cari.CA_MUTABAKAT_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE"));
                            cari.CA_MUT_MEKTUP_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI"));
                            cari.CA_MUT_MEKTUP_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE"));
                            cari.CA_RISK_LIMITI = reader.IsDBNull(reader.GetOrdinal("CA_RISK_LIMITI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_RISK_LIMITI"));
                            cari.CA_TEMINAT_TUTARI = reader.IsDBNull(reader.GetOrdinal("CA_TEMINAT_TUTARI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_TEMINAT_TUTARI"));
                            cari.CA_CEK_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_ASIL_RISKI"));
                            cari.CA_CEK_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_CIRO_RISKI"));
                            cari.CA_SENET_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_ASIL_RISKI"));
                            cari.CA_SENET_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_CIRO_RISKI"));
                            cari.CA_BORC = reader.IsDBNull(reader.GetOrdinal("CA_BORC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_BORC"));
                            cari.CA_ALACAK = reader.IsDBNull(reader.GetOrdinal("CA_ALACAK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ALACAK"));
                            cari.CA_NOTLAR = reader.IsDBNull(reader.GetOrdinal("CA_NOTLAR")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_NOTLAR"));
                            cari.CA_KTA_BOLGE_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_BOLGE_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_BOLGE_KODU"));
                            cari.CA_KTA_GRUP_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_GRUP_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_GRUP_KODU"));
                            cari.CA_KTA_OZEL_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KTA_OZEL_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_OZEL_KOD"));
                            cari.CA_TLF_CEP = reader.IsDBNull(reader.GetOrdinal("CA_TLF_CEP")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_CEP"));
                            cari.CA_TLF_FAKS = reader.IsDBNull(reader.GetOrdinal("CA_TLF_FAKS")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_FAKS"));
                            cari.CA_TLF_TELEFON = reader.IsDBNull(reader.GetOrdinal("CA_TLF_TELEFON")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_TELEFON"));
                            items.Add(cari);
                        }
                    }
                }
            }


            return items;
        }
        public List<RivaCari> GetCari(int CariId)
        {
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
            SELECT 
            r.CA_ID, r.CA_KOD, r.CA_UNVAN, r.CA_CARI_TIP_ID, r.CA_ADRES, r.CA_ILCE,
            r.CA_IL, r.CA_POSTA_KODU, r.CA_VERGI_DAIRESI, r.CA_VERGI_NUMARASI,
            r.CA_ULKE_ID, r.CA_TC_KIMLIK_NO, r.CA_MUHASEBE_ID, r.CA_PLASIYER_ID,
            r.CA_LISTE_FIYATI, r.CA_DOVIZ_ID, r.CA_ISKONTO_ORANI,
            r.CA_NAKLIYE_KATSAYISI, r.CA_ODEME_GUNU, r.CA_VADE_GUNU,
            r.CA_MUTABAKAT_TARIHI, r.CA_MUTABAKAT_BAKIYE, r.CA_MUT_MEKTUP_TARIHI,
            r.CA_MUT_MEKTUP_BAKIYE, r.CA_RISK_LIMITI, r.CA_TEMINAT_TUTARI,
            r.CA_CEK_ASIL_RISKI, r.CA_CEK_CIRO_RISKI, r.CA_SENET_ASIL_RISKI,
            r.CA_SENET_CIRO_RISKI, r.CA_BORC, r.CA_ALACAK, r.CA_NOTLAR,
            r.CA_KTA_BOLGE_KODU, r.CA_KTA_GRUP_KODU, r.CA_KTA_OZEL_KOD, r.CA_TLF_CEP,
            r.CA_TLF_FAKS, r.CA_TLF_TELEFON
            FROM CARI r 
            WHERE 
          r.CA_ID = '{CariId}'

        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RivaCari cari = new RivaCari();
                            cari.CA_ID = reader.IsDBNull(reader.GetOrdinal("CA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ID"));
                            cari.CA_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KOD"));
                            cari.CA_UNVAN = reader.IsDBNull(reader.GetOrdinal("CA_UNVAN")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_UNVAN"));
                            cari.CA_CARI_TIP_ID = reader.IsDBNull(reader.GetOrdinal("CA_CARI_TIP_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_CARI_TIP_ID"));
                            cari.CA_ADRES = reader.IsDBNull(reader.GetOrdinal("CA_ADRES")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ADRES"));
                            cari.CA_ILCE = reader.IsDBNull(reader.GetOrdinal("CA_ILCE")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ILCE"));
                            cari.CA_IL = reader.IsDBNull(reader.GetOrdinal("CA_IL")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_IL"));
                            cari.CA_POSTA_KODU = reader.IsDBNull(reader.GetOrdinal("CA_POSTA_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_POSTA_KODU"));
                            cari.CA_VERGI_DAIRESI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_DAIRESI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_DAIRESI"));
                            cari.CA_VERGI_NUMARASI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_NUMARASI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_NUMARASI"));
                            cari.CA_ULKE_ID = reader.IsDBNull(reader.GetOrdinal("CA_ULKE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ULKE_ID"));
                            cari.CA_TC_KIMLIK_NO = reader.IsDBNull(reader.GetOrdinal("CA_TC_KIMLIK_NO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TC_KIMLIK_NO"));
                            cari.CA_MUHASEBE_ID = reader.IsDBNull(reader.GetOrdinal("CA_MUHASEBE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_MUHASEBE_ID"));
                            cari.CA_PLASIYER_ID = reader.IsDBNull(reader.GetOrdinal("CA_PLASIYER_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_PLASIYER_ID"));
                            //cari.CA_LISTE_FIYATI = reader.IsDBNull(reader.GetOrdinal("CA_LISTE_FIYATI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_LISTE_FIYATI"));
                            cari.CA_DOVIZ_ID = reader.IsDBNull(reader.GetOrdinal("CA_DOVIZ_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_DOVIZ_ID"));
                            cari.CA_ISKONTO_ORANI = reader.IsDBNull(reader.GetOrdinal("CA_ISKONTO_ORANI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ISKONTO_ORANI"));
                            cari.CA_NAKLIYE_KATSAYISI = reader.IsDBNull(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI"));
                            cari.CA_ODEME_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_ODEME_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ODEME_GUNU"));
                            cari.CA_VADE_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_VADE_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_VADE_GUNU"));
                            cari.CA_MUTABAKAT_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUTABAKAT_TARIHI"));
                            cari.CA_MUTABAKAT_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE"));
                            cari.CA_MUT_MEKTUP_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI"));
                            cari.CA_MUT_MEKTUP_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE"));
                            cari.CA_RISK_LIMITI = reader.IsDBNull(reader.GetOrdinal("CA_RISK_LIMITI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_RISK_LIMITI"));
                            cari.CA_TEMINAT_TUTARI = reader.IsDBNull(reader.GetOrdinal("CA_TEMINAT_TUTARI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_TEMINAT_TUTARI"));
                            cari.CA_CEK_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_ASIL_RISKI"));
                            cari.CA_CEK_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_CIRO_RISKI"));
                            cari.CA_SENET_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_ASIL_RISKI"));
                            cari.CA_SENET_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_CIRO_RISKI"));
                            cari.CA_BORC = reader.IsDBNull(reader.GetOrdinal("CA_BORC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_BORC"));
                            cari.CA_ALACAK = reader.IsDBNull(reader.GetOrdinal("CA_ALACAK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ALACAK"));
                            cari.CA_NOTLAR = reader.IsDBNull(reader.GetOrdinal("CA_NOTLAR")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_NOTLAR"));
                            cari.CA_KTA_BOLGE_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_BOLGE_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_BOLGE_KODU"));
                            cari.CA_KTA_GRUP_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_GRUP_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_GRUP_KODU"));
                            cari.CA_KTA_OZEL_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KTA_OZEL_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_OZEL_KOD"));
                            cari.CA_TLF_CEP = reader.IsDBNull(reader.GetOrdinal("CA_TLF_CEP")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_CEP"));
                            cari.CA_TLF_FAKS = reader.IsDBNull(reader.GetOrdinal("CA_TLF_FAKS")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_FAKS"));
                            cari.CA_TLF_TELEFON = reader.IsDBNull(reader.GetOrdinal("CA_TLF_TELEFON")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_TELEFON"));
                            items.Add(cari);
                        }
                    }
                }
            }


            return items;
        }
        public List<RivaCari> GetCariByString(string Aranan)
        {

            var items = new List<RivaCari>();

            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
         SELECT 
            r.CA_ID, r.CA_KOD, r.CA_UNVAN, r.CA_CARI_TIP_ID, r.CA_ADRES, r.CA_ILCE,
            r.CA_IL, r.CA_POSTA_KODU, r.CA_VERGI_DAIRESI, r.CA_VERGI_NUMARASI,
            r.CA_ULKE_ID, r.CA_TC_KIMLIK_NO, r.CA_MUHASEBE_ID, r.CA_PLASIYER_ID,
            r.CA_LISTE_FIYATI, r.CA_DOVIZ_ID, r.CA_ISKONTO_ORANI,
            r.CA_NAKLIYE_KATSAYISI, r.CA_ODEME_GUNU, r.CA_VADE_GUNU,
            r.CA_MUTABAKAT_TARIHI, r.CA_MUTABAKAT_BAKIYE, r.CA_MUT_MEKTUP_TARIHI,
            r.CA_MUT_MEKTUP_BAKIYE, r.CA_RISK_LIMITI, r.CA_TEMINAT_TUTARI,
            r.CA_CEK_ASIL_RISKI, r.CA_CEK_CIRO_RISKI, r.CA_SENET_ASIL_RISKI,
            r.CA_SENET_CIRO_RISKI, r.CA_BORC, r.CA_ALACAK, r.CA_NOTLAR,
            r.CA_KTA_BOLGE_KODU, r.CA_KTA_GRUP_KODU, r.CA_KTA_OZEL_KOD, r.CA_TLF_CEP,
            r.CA_TLF_FAKS, r.CA_TLF_TELEFON
        FROM CARI r 

            where r.CA_UNVAN like '%{Aranan.ToUpper()}%' or r.CA_UNVAN like '%{Aranan.ToUpper()}%'

        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RivaCari cari = new RivaCari();
                            cari.CA_ID = reader.IsDBNull(reader.GetOrdinal("CA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ID"));
                            cari.CA_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KOD"));
                            cari.CA_UNVAN = reader.IsDBNull(reader.GetOrdinal("CA_UNVAN")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_UNVAN"));
                            cari.CA_CARI_TIP_ID = reader.IsDBNull(reader.GetOrdinal("CA_CARI_TIP_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_CARI_TIP_ID"));
                            cari.CA_ADRES = reader.IsDBNull(reader.GetOrdinal("CA_ADRES")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ADRES"));
                            cari.CA_ILCE = reader.IsDBNull(reader.GetOrdinal("CA_ILCE")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ILCE"));
                            cari.CA_IL = reader.IsDBNull(reader.GetOrdinal("CA_IL")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_IL"));
                            cari.CA_POSTA_KODU = reader.IsDBNull(reader.GetOrdinal("CA_POSTA_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_POSTA_KODU"));
                            cari.CA_VERGI_DAIRESI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_DAIRESI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_DAIRESI"));
                            cari.CA_VERGI_NUMARASI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_NUMARASI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_NUMARASI"));
                            cari.CA_ULKE_ID = reader.IsDBNull(reader.GetOrdinal("CA_ULKE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ULKE_ID"));
                            cari.CA_TC_KIMLIK_NO = reader.IsDBNull(reader.GetOrdinal("CA_TC_KIMLIK_NO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TC_KIMLIK_NO"));
                            cari.CA_MUHASEBE_ID = reader.IsDBNull(reader.GetOrdinal("CA_MUHASEBE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_MUHASEBE_ID"));
                            cari.CA_PLASIYER_ID = reader.IsDBNull(reader.GetOrdinal("CA_PLASIYER_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_PLASIYER_ID"));
                            //cari.CA_LISTE_FIYATI = reader.IsDBNull(reader.GetOrdinal("CA_LISTE_FIYATI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_LISTE_FIYATI"));
                            cari.CA_DOVIZ_ID = reader.IsDBNull(reader.GetOrdinal("CA_DOVIZ_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_DOVIZ_ID"));
                            cari.CA_ISKONTO_ORANI = reader.IsDBNull(reader.GetOrdinal("CA_ISKONTO_ORANI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ISKONTO_ORANI"));
                            cari.CA_NAKLIYE_KATSAYISI = reader.IsDBNull(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI"));
                            cari.CA_ODEME_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_ODEME_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ODEME_GUNU"));
                            cari.CA_VADE_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_VADE_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_VADE_GUNU"));
                            cari.CA_MUTABAKAT_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUTABAKAT_TARIHI"));
                            cari.CA_MUTABAKAT_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE"));
                            cari.CA_MUT_MEKTUP_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI"));
                            cari.CA_MUT_MEKTUP_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE"));
                            cari.CA_RISK_LIMITI = reader.IsDBNull(reader.GetOrdinal("CA_RISK_LIMITI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_RISK_LIMITI"));
                            cari.CA_TEMINAT_TUTARI = reader.IsDBNull(reader.GetOrdinal("CA_TEMINAT_TUTARI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_TEMINAT_TUTARI"));
                            cari.CA_CEK_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_ASIL_RISKI"));
                            cari.CA_CEK_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_CIRO_RISKI"));
                            cari.CA_SENET_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_ASIL_RISKI"));
                            cari.CA_SENET_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_CIRO_RISKI"));
                            cari.CA_BORC = reader.IsDBNull(reader.GetOrdinal("CA_BORC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_BORC"));
                            cari.CA_ALACAK = reader.IsDBNull(reader.GetOrdinal("CA_ALACAK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ALACAK"));
                            cari.CA_NOTLAR = reader.IsDBNull(reader.GetOrdinal("CA_NOTLAR")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_NOTLAR"));
                            cari.CA_KTA_BOLGE_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_BOLGE_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_BOLGE_KODU"));
                            cari.CA_KTA_GRUP_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_GRUP_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_GRUP_KODU"));
                            cari.CA_KTA_OZEL_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KTA_OZEL_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_OZEL_KOD"));
                            cari.CA_TLF_CEP = reader.IsDBNull(reader.GetOrdinal("CA_TLF_CEP")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_CEP"));
                            cari.CA_TLF_FAKS = reader.IsDBNull(reader.GetOrdinal("CA_TLF_FAKS")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_FAKS"));
                            cari.CA_TLF_TELEFON = reader.IsDBNull(reader.GetOrdinal("CA_TLF_TELEFON")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_TELEFON"));
                            items.Add(cari);
                        }
                    }
                }
            }


            return items;
        }
        public string GetLastFaturaNo(string CariKod)
        {
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
                 
                
  SELECT first 1 r.FT_EVRAK_NO
     FROM FATURA r 
     inner join CARI c
     on c.CA_ID = r.FT_CARI_ID
     
     where c.CA_KOD like '%{CariKod}%'
     
     
      order by r.FT_EVRAK_NO descending

";
            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<FaturaDto>();

                        while (reader.Read())
                        {
                            FaturaDto fatura = new FaturaDto();

                            fatura.FT_EVRAK_NO = reader.IsDBNull(0) ? null : reader.GetString(0);

                            faturaBaslık.Add(fatura);
                        }
                        return (Convert.ToInt64(faturaBaslık.FirstOrDefault().FT_EVRAK_NO) + 1).ToString().PadLeft(10, '0');
                    }
                }
            }
        }
        public List<FaturaDto> FaturalarInfinify(int pageNumber, string EvrakNo, string CariAdı, DateTime StartDate, DateTime EndDate)
        {
            int pageSize = 10; // Sayfa boyutu
            int offset = (pageNumber - 1) * pageSize; // Atlanacak kayıt sayısını hesapla
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
           SELECT FIRST @PageSize SKIP @Offset r.FT_ID, r.FT_EVRAK_TIPI, r.FT_EVRAK_NO, r.FT_CARI_ID, r.FT_UNVAN,
                r.FT_ADRES, r.FT_ILCE, r.FT_IL, r.FT_POSTA_KODU, r.FT_VERGI_DAIRESI,
                r.FT_VERGI_NUMARASI, r.FT_BABA_ADI, r.FT_DOGUM_YERI, r.FT_DOGUM_TARIHI,
                r.FT_BAGKUR_DAIRESI, r.FT_BAGKUR_NUMARASI, r.FT_TC_KIMLIK_NUMARASI,
                r.FT_ACIKLAMA, r.FT_TIP, r.FT_TARIH, r.FT_ZAMAN, r.FT_VADE_TARIHI,
                r.FT_KDV_VADE_TARIHI, r.FT_TESLIM_TARIHI, r.FT_LISTE_FIYATI, r.FT_DOVIZ_ID,
                r.FT_DOVIZ_KUR_TARIHI, r.FT_DOVIZ_TUTAR, r.FT_DEPO_ID, r.FT_PLASIYER_ID,
                r.FT_BRUT_TOPLAM, r.FT_MAL_FAZLASI_ISK, r.FT_SATIR_ISK_TOPLAMI,
                r.FT_GENEL_ISK_MATRAHI, r.FT_GENEL_ISK_TOPLAMI, r.FT_MUS_STOPAJ,
                r.FT_MUS_FON, r.FT_MUS_BORSA, r.FT_MUS_MERA, r.FT_MUS_BAGKUR,
                r.FT_MUS_KES_TOPLAMI, r.FT_KALEM_SAYISI, r.FT_TOPLAM_MIKTAR,
                r.FT_TOPLAM_AGIRLIK, r.FT_NAKLIYE_TUTARI, r.FT_NAKLIYE_TUTARI_KDV,
                r.FT_EK_MALIYET_TOPLAMI, r.FT_VADE_FARKI, r.FT_VADE_FARKI_KDV,
                r.FT_KDV_TOPLAMI, r.FT_KDV_TOPLAMI_YUV, r.FT_GENEL_TOPLAM,
                r.FT_GENEL_TOPLAM_YUV, r.FT_KDV_DAHIL, r.FT_KDV_ISK_ONCE_DUS,
                r.FT_KDV_MAL_FAZLASI, r.FT_KDV_MAL_FAZLA_NET, r.FT_CARIYE_KAYIT,
                r.FT_PESINAT_AYRILSIN, r.FT_STOKLARA_KAYIT, r.FT_STOK_IRS_TARIHI,
                r.FT_STOK_MAL_EK_MALIYET, r.FT_STOK_MAL_NAKLIYE, r.FT_KAPATILMIS,
                r.FT_KARSILANMIS, r.FT_NOTLAR, r.FT_SIS_01, r.FT_SIS_02, r.FT_SIS_03,
                r.FT_GIS_01, r.FT_GIS_02, r.FT_GIS_03, r.FT_EMT_01, r.FT_EMT_02,
                r.FT_EMT_03, r.FT_EMK_01, r.FT_EMK_02, r.FT_EMK_03
                FROM FATURA r

            WHERE 
          r.FT_EVRAK_NO LIKE '%{EvrakNo}%' 
        or r.FT_UNVAN LIKE '%{CariAdı}%' 
         AND r.FT_TARIH BETWEEN @BaslangicTarihi AND @BitisTarihi
        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@BaslangicTarihi", StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@BitisTarihi", EndDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<FaturaDto>();

                        while (reader.Read())
                        {
                            var stok = MapToEntity<FaturaDto>(reader);
                            faturaBaslık.Add(stok);

                            //faturaBaslık.Add(fatura);
                        }
                        return faturaBaslık;

                    }
                }
            }



        }
        public List<FaturaDto> FaturalarSeçili(int pageNumber, DateTime StartDate, DateTime EndDate, string[] FaturaIds)
        {
            int pageSize = 10; // Sayfa boyutu
            int offset = (pageNumber - 1) * pageSize; // Atlanacak kayıt sayısını hesapla
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            var faturIds = string.Join(",", FaturaIds);

            string query = $@"
               SELECT FIRST @PageSize SKIP @Offset *
                    FROM FATURA r
                WHERE 
                r.FT_ID IN ({faturIds})
       
                AND r.FT_TARIH BETWEEN @BaslangicTarihi AND @BitisTarihi
        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@BaslangicTarihi", StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@BitisTarihi", EndDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<FaturaDto>();

                        while (reader.Read())
                        {
                            var stok = MapToEntity<FaturaDto>(reader);
                            faturaBaslık.Add(stok);

                            //faturaBaslık.Add(fatura);
                        }
                        return faturaBaslık;

                    }
                }
            }



        }
        public List<string> FaturalaIdLeriGetir(int[] StokIds, int[] CariIds)
        {
            List<string> SorguParçaları = new List<string>();

            if (StokIds.Length > 0)
            {
                SorguParçaları.Add(" d.FD_STOK_ID in (" + string.Join(",", StokIds) + ") ");
            }
            if (CariIds.Length > 0)
            {
                SorguParçaları.Add(" r.FT_CARI_ID in (" + string.Join(",", CariIds) + ") ");
            }

            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
                SELECT DISTINCT  FT_ID
                FROM FATURA r
                inner join FATURADETAY  d
                on d.FD_FATURA_ID = r.FT_ID
                {((StokIds.Length > 0 || CariIds.Length > 0) ? "where " + string.Join(" and ", SorguParçaları) : "")}
            ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<string>();

                        while (reader.Read())
                        {
                            faturaBaslık.Add(reader.GetString(0));
                        }
                        return faturaBaslık;

                    }
                }
            }



        }
        public List<RivaCari> CarileriGetir(int pageNumber, string[] CariIds)
        {
            int pageSize = 10; // Sayfa boyutu
            int offset = (pageNumber - 1) * pageSize; // Atlanacak kayıt sayısını hesapla
            var items = new List<RivaCari>();
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
                 SELECT FIRST @PageSize SKIP @Offset
                    r.CA_ID, r.CA_KOD, r.CA_UNVAN, r.CA_CARI_TIP_ID, r.CA_ADRES, r.CA_ILCE,
                    r.CA_IL, r.CA_POSTA_KODU, r.CA_VERGI_DAIRESI, r.CA_VERGI_NUMARASI,
                    r.CA_ULKE_ID, r.CA_TC_KIMLIK_NO, r.CA_MUHASEBE_ID, r.CA_PLASIYER_ID,
                    r.CA_LISTE_FIYATI, r.CA_DOVIZ_ID, r.CA_ISKONTO_ORANI,
                    r.CA_NAKLIYE_KATSAYISI, r.CA_ODEME_GUNU, r.CA_VADE_GUNU,
                    r.CA_MUTABAKAT_TARIHI, r.CA_MUTABAKAT_BAKIYE, r.CA_MUT_MEKTUP_TARIHI,
                    r.CA_MUT_MEKTUP_BAKIYE, r.CA_RISK_LIMITI, r.CA_TEMINAT_TUTARI,
                    r.CA_CEK_ASIL_RISKI, r.CA_CEK_CIRO_RISKI, r.CA_SENET_ASIL_RISKI,
                    r.CA_SENET_CIRO_RISKI, r.CA_BORC, r.CA_ALACAK, r.CA_NOTLAR,
                    r.CA_KTA_BOLGE_KODU, r.CA_KTA_GRUP_KODU, r.CA_KTA_OZEL_KOD, r.CA_TLF_CEP,
                    r.CA_TLF_FAKS, r.CA_TLF_TELEFON
                FROM CARI r 
        
          {(CariIds.Length >= 1 ? @$"WHERE  r.CA_ID in ({string.Join(",", CariIds)})" : "")}

        ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", offset);


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RivaCari cari = new RivaCari();
                            cari.CA_ID = reader.IsDBNull(reader.GetOrdinal("CA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ID"));
                            cari.CA_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KOD"));
                            cari.CA_UNVAN = reader.IsDBNull(reader.GetOrdinal("CA_UNVAN")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_UNVAN"));
                            cari.CA_CARI_TIP_ID = reader.IsDBNull(reader.GetOrdinal("CA_CARI_TIP_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_CARI_TIP_ID"));
                            cari.CA_ADRES = reader.IsDBNull(reader.GetOrdinal("CA_ADRES")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ADRES"));
                            cari.CA_ILCE = reader.IsDBNull(reader.GetOrdinal("CA_ILCE")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_ILCE"));
                            cari.CA_IL = reader.IsDBNull(reader.GetOrdinal("CA_IL")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_IL"));
                            cari.CA_POSTA_KODU = reader.IsDBNull(reader.GetOrdinal("CA_POSTA_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_POSTA_KODU"));
                            cari.CA_VERGI_DAIRESI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_DAIRESI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_DAIRESI"));
                            cari.CA_VERGI_NUMARASI = reader.IsDBNull(reader.GetOrdinal("CA_VERGI_NUMARASI")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_VERGI_NUMARASI"));
                            cari.CA_ULKE_ID = reader.IsDBNull(reader.GetOrdinal("CA_ULKE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ULKE_ID"));
                            cari.CA_TC_KIMLIK_NO = reader.IsDBNull(reader.GetOrdinal("CA_TC_KIMLIK_NO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TC_KIMLIK_NO"));
                            cari.CA_MUHASEBE_ID = reader.IsDBNull(reader.GetOrdinal("CA_MUHASEBE_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_MUHASEBE_ID"));
                            cari.CA_PLASIYER_ID = reader.IsDBNull(reader.GetOrdinal("CA_PLASIYER_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_PLASIYER_ID"));
                            //cari.CA_LISTE_FIYATI = reader.IsDBNull(reader.GetOrdinal("CA_LISTE_FIYATI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_LISTE_FIYATI"));
                            cari.CA_DOVIZ_ID = reader.IsDBNull(reader.GetOrdinal("CA_DOVIZ_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_DOVIZ_ID"));
                            cari.CA_ISKONTO_ORANI = reader.IsDBNull(reader.GetOrdinal("CA_ISKONTO_ORANI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ISKONTO_ORANI"));
                            cari.CA_NAKLIYE_KATSAYISI = reader.IsDBNull(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_NAKLIYE_KATSAYISI"));
                            cari.CA_ODEME_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_ODEME_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_ODEME_GUNU"));
                            cari.CA_VADE_GUNU = reader.IsDBNull(reader.GetOrdinal("CA_VADE_GUNU")) ? 0 : reader.GetInt32(reader.GetOrdinal("CA_VADE_GUNU"));
                            cari.CA_MUTABAKAT_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUTABAKAT_TARIHI"));
                            cari.CA_MUTABAKAT_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUTABAKAT_BAKIYE"));
                            cari.CA_MUT_MEKTUP_TARIHI = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CA_MUT_MEKTUP_TARIHI"));
                            cari.CA_MUT_MEKTUP_BAKIYE = reader.IsDBNull(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_MUT_MEKTUP_BAKIYE"));
                            cari.CA_RISK_LIMITI = reader.IsDBNull(reader.GetOrdinal("CA_RISK_LIMITI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_RISK_LIMITI"));
                            cari.CA_TEMINAT_TUTARI = reader.IsDBNull(reader.GetOrdinal("CA_TEMINAT_TUTARI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_TEMINAT_TUTARI"));
                            cari.CA_CEK_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_ASIL_RISKI"));
                            cari.CA_CEK_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_CEK_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_CEK_CIRO_RISKI"));
                            cari.CA_SENET_ASIL_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_ASIL_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_ASIL_RISKI"));
                            cari.CA_SENET_CIRO_RISKI = reader.IsDBNull(reader.GetOrdinal("CA_SENET_CIRO_RISKI")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_SENET_CIRO_RISKI"));
                            cari.CA_BORC = reader.IsDBNull(reader.GetOrdinal("CA_BORC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_BORC"));
                            cari.CA_ALACAK = reader.IsDBNull(reader.GetOrdinal("CA_ALACAK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("CA_ALACAK"));
                            cari.CA_NOTLAR = reader.IsDBNull(reader.GetOrdinal("CA_NOTLAR")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_NOTLAR"));
                            cari.CA_KTA_BOLGE_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_BOLGE_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_BOLGE_KODU"));
                            cari.CA_KTA_GRUP_KODU = reader.IsDBNull(reader.GetOrdinal("CA_KTA_GRUP_KODU")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_GRUP_KODU"));
                            cari.CA_KTA_OZEL_KOD = reader.IsDBNull(reader.GetOrdinal("CA_KTA_OZEL_KOD")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_KTA_OZEL_KOD"));
                            cari.CA_TLF_CEP = reader.IsDBNull(reader.GetOrdinal("CA_TLF_CEP")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_CEP"));
                            cari.CA_TLF_FAKS = reader.IsDBNull(reader.GetOrdinal("CA_TLF_FAKS")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_FAKS"));
                            cari.CA_TLF_TELEFON = reader.IsDBNull(reader.GetOrdinal("CA_TLF_TELEFON")) ? string.Empty : reader.GetString(reader.GetOrdinal("CA_TLF_TELEFON"));
                            items.Add(cari);
                        }
                    }
                }
            }


            return items;
        }



        public List<RivaStokHareket> StokHareketGetir(int StokId)
        {
            List<RivaStokHareket> rivaStokHarekets = new List<RivaStokHareket>();

            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();

                string query = $@"
            SELECT r.SH_ID, r.SH_ENTEGRA_TIP, r.SH_ENTEGRA_ID, r.SH_STOK_ID,
                r.SH_ISLEM_TARIHI, r.SH_ISLEM_TIPI, r.SH_GIRIS_CIKIS, r.SH_EVRAK_NO,
                r.SH_ACIKLAMA, r.SH_CARI_ID, r.SH_DEPO_ID, r.SH_PLASIYER_ID,
                r.SH_OLCU_BIRIMI, r.SH_MIKTAR, r.SH_MIKTAR2, r.SH_DOVIZ_ID,
                r.SH_DOVIZ_TUTAR, r.SH_TUTAR, r.SH_ISKONTO_TUTARI, r.SH_KDV_TUTARI,
                r.SH_MASRAF_TUTARI,s.SK_ISIM

            FROM STOKHAREKET r 
            inner join STOK s
            on s.SK_ID = r.SH_STOK_ID

            where r.SH_STOK_ID = '{StokId}'
                ";

                using (var command = new FbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var stok = MapToEntity<RivaStokHareket>(reader);
                        rivaStokHarekets.Add(stok);
                    }
                }
            }



            return rivaStokHarekets;
        }
        public class rivaStokRapor
        {
            public string StokId { get; set; }
            public string StokAdı { get; set; }
            public string Miktar { get; set; }
        }
        public List<rivaStokRapor> FaturalaStokSonuçGetir(string[] FaturaIds)
        {
            if (FaturaIds.Length <= 0)
            {
                return null;
            }
            string connectionString = _connectionString; // Veritabanı bağlantı stringi
            string query = $@"
              SELECT r.FD_STOK_ID,r.FD_STOK_BASLIK,SUM(r.FD_MIKTAR)
                FROM FATURADETAY r where r.FD_FATURA_ID in ({string.Join(",", FaturaIds)}) GROUP BY r.FD_STOK_ID ,r.FD_STOK_BASLIK
            ";

            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var command = new FbCommand(query, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        var faturaBaslık = new List<rivaStokRapor>();

                        while (reader.Read())
                        {
                            rivaStokRapor rivaStokRapor = new rivaStokRapor();
                            rivaStokRapor.StokId = reader.GetString(0);
                            rivaStokRapor.StokAdı = reader.GetString(1);
                            rivaStokRapor.Miktar = reader.GetString(2);
                            faturaBaslık.Add(rivaStokRapor);
                        }
                        return faturaBaslık;
                    }
                }
            }



        }
        #endregion
        public IActionResult StokGetirId(string Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            res.data = GetStokById(Id);
            res.message = "İşlem Başarılı";
            res.status = 1;
            return Json(res);
        }
        public IActionResult BarkodUrunAraHarf(string q)
        {
            var stok = GetStokByBarkod(q);
            JsonResponseModel res = new JsonResponseModel();
            res.data = stok;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult BarkodUrunAra(string Barkod)
        {
            JsonResponseModel res = new JsonResponseModel();
            List<RivaStok> stok = new List<RivaStok>();
            if (String.IsNullOrEmpty(Barkod))
            {
                res.data = null;
                res.status = 1;
                return Json(res);
            }
            try
            {
                stok = GetStokByBarkod(Barkod.ToUpper());
            }
            catch (Exception ex)
            {

                res.data = stok;
                res.status = 1;
                res.message = ex.Message;
                return Json(res);
            }
            res.data = stok;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult HızlıButonGetir(int ParentId = 0)
        {
            JsonResponseModel res = new JsonResponseModel();

            var userId = _userManager.GetUserId(HttpContext.User);
            var ayar = _sıcakSatışAyarRepository.Get(o => o.UserId == userId);
            if (ayar == null)
            {
                res.status = 0;
                res.message = "Lütfen Ayarları Düzenleyin";

                return Json(res);
            }

            var hızlıButonlar = _sıcakSatışHızlıButonRepository.GetAll(o => o.sıcakSatışButonProfilId == ayar.HızlıButonProfilId && o.ParentId == ParentId);


            res.status = 1;
            res.message = "İşlem Başarılı";
            res.data = hızlıButonlar;

            return Json(res);
        }
        public class Satırlar
        {
            public decimal GenelTutar { get; set; }
            public decimal birimFiyat { get; set; }
            public decimal iskonto { get; set; }
            public decimal kdv { get; set; }
            public decimal miktar { get; set; }
            public decimal ürünId { get; set; }
            public string ÜrünAdı { get; set; }
        }
        public class GenelBilgiler
        {
            public List<Satırlar> Satırlar { get; set; }
            public string BelgeNo { get; set; }
            public string ToplamKdv { get; set; }
            public string Toplamİskonto { get; set; }
            public string GenelTutar { get; set; }
        }

        public async Task<IActionResult> FişKapat(Satırlar[] satırlar, string KrediÖdeme, string NakitÖdeme, string CariÖdeme, bool FişYazılsınmı, string CariKodu = null)
        {
            JsonResponseModel res = new JsonResponseModel();
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                SıcakSatışAyar ayar = new SıcakSatışAyar();
                if (userId == null)
                {
                    ayar = _sıcakSatışAyarRepository.Get(o => o.UserId == "65884dec-abf8-43a9-b52e-8065e20aea5a");
                }
                else
                {
                    ayar = _sıcakSatışAyarRepository.Get(o => o.UserId == userId);
                }
                if (ayar.CariKodu != null)
                {
                    ayar.CariKodu = CariKodu;
                }
                var FaturaEvrakNo = "";
                try
                {
                    FaturaEvrakNo = GetLastFaturaNo(ayar.CariKodu);
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Fatura No Alınırken Hata Oluştu" + ex.Message;
                    return Json(res);
                }
                var cariId = 0;
                try
                {
                    cariId = GetCari(ayar.CariKodu).FirstOrDefault().CA_ID;
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Cari Id Alınırken Hata Oluştu" + ex.Message;
                    return Json(res);
                }

                decimal brütToplam = 0;
                var kalemSayııs = satırlar.ToList().GroupBy(o => o.ürünId).ToList().Count();
                var toplamMiktar = satırlar.Sum(o => o.miktar);
                decimal toplamİskonto = 0;
                decimal kdvToplam = 0;
                // var GenelTutar = ((parseFloat(BirimFiyat) * parseFloat(miktar)) + (parseFloat(BirimFiyat) * parseFloat(miktar)) * parseFloat(Kdv) / 100 - (parseFloat(BirimFiyat) * parseFloat(miktar)) * parseFloat(İskonto) / 100)
                try
                {
                    foreach (var item in satırlar)
                    {
                        decimal iskontoluBirimFiyat = item.birimFiyat - (item.birimFiyat * item.iskonto / 100M);
                        toplamİskonto += item.birimFiyat - iskontoluBirimFiyat;
                        decimal araToplam = iskontoluBirimFiyat * item.miktar;
                        decimal kdvTutarı = araToplam * item.kdv / 100M;
                        brütToplam += araToplam + kdvTutarı;
                        kdvToplam += kdvTutarı;
                    }
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Fatura Satırları Toplanırken Hata Oluştu" + ex.Message;
                    return Json(res);
                }
                var faturaId = 0L;
                try
                {
                    faturaId = (FaturaGir(cariId, brütToplam, kalemSayııs, Convert.ToInt64(toplamMiktar), kdvToplam, FaturaEvrakNo) + 1);
                }
                catch (Exception ex)
                {

                    res.status = 0;
                    res.message = "Fatura Girilirken Hata Oluştu" + ex.Message;
                    return Json(res);
                }
                var carihareketId = 0L;

                try
                {
                    var sıraNo = 0;
                    foreach (var item in satırlar)
                    {
                        var stokAdı = GetStokById(item.ürünId.ToString()).FirstOrDefault();
                        satırlar[sıraNo].ÜrünAdı = stokAdı.SK_ISIM;
                        sıraNo++;
                        var iskontoluBirimFiyat = item.birimFiyat - (item.birimFiyat / 100 * item.iskonto);
                        var satırToplam = ((iskontoluBirimFiyat * item.miktar)) + ((iskontoluBirimFiyat * item.miktar) / 100 * item.kdv);
                        var faturaSatırId = FaturaSatırGir(faturaId.ToString(), sıraNo.ToString(), item.ürünId.ToString(), stokAdı.SK_ISIM, cariId.ToString(), item.miktar, stokAdı.SK_OLCU1_BIRIM, satırToplam, item.kdv.ToString());

                        var _satırToplam = ((iskontoluBirimFiyat * item.miktar)) + ((iskontoluBirimFiyat * item.miktar) / 100 * item.kdv);
                        StokHareketiGir((faturaSatırId + 1).ToString(), item.ürünId.ToString(), FaturaEvrakNo, cariId.ToString(), stokAdı.SK_OLCU1_BIRIM, ConverToString((-item.miktar)), (-_satırToplam));
                    }
                    carihareketId = CariHareketGir(cariId.ToString(), (faturaId).ToString(), FaturaEvrakNo.ToString(), brütToplam, Açıklama: "Faturamiz");

                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Stok Hareket Girilirken Hata Oluştu" + ex.Message;
                    return Json(res);
                }

                try
                {
                    if (Convert.ToDecimal(KrediÖdeme) > 0)
                    {
                        var kasa = GetKasa(ayar.KrediKasaKodu).FirstOrDefault();
                        if (kasa == null)
                        {
                            res.status = 0;
                            res.message = "Kasa Bulunamadı";
                            return Json(res);
                        }
                        var kasaHareketNo = GetKasaHareketiLastEvrakNo();
                        if (String.IsNullOrEmpty(kasaHareketNo))
                        {
                            res.status = 0;
                            res.message = "Kasa Kasa Last Hareket No Bulunamadı";
                            return Json(res);
                        }
                        var x = KrediÖdeme;
                        var kasaHareketId = KasaHareketGir(kasa.KS_ID.ToString(), kasaHareketNo, Convert.ToDecimal(KrediÖdeme.Replace(",", "").Replace(".", ",")), cariId.ToString(), faturaId.ToString());
                        carihareketId = CariHareketGir(cariId.ToString(), (kasaHareketId + 1).ToString(), FaturaEvrakNo.ToString(), (-brütToplam), "-10", Açıklama: " no'lu Faturamız (Peşinat)", "1095975243");
                    }
                    if (Convert.ToDecimal(NakitÖdeme) > 0)
                    {
                        var kasa = GetKasa(ayar.NakitKasaKodu).FirstOrDefault();
                        var kasaHareketNo = GetKasaHareketiLastEvrakNo();
                        var kasaHareketId = KasaHareketGir(kasa.KS_ID.ToString(), kasaHareketNo, Convert.ToDecimal(NakitÖdeme.Replace(",", "").Replace(".", ",")), cariId.ToString(), faturaId.ToString());
                        carihareketId = CariHareketGir(cariId.ToString(), (kasaHareketId + 1).ToString(), FaturaEvrakNo.ToString(), (-brütToplam), "-10", Açıklama: "Faturamiz(Peşinat)", "1095975243");

                    }
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Kasa Hareket Girilirken Hata Oluştu" + ex.Message;
                    return Json(res);
                }



                var genelBilgiler = new GenelBilgiler();
                genelBilgiler.Satırlar = satırlar.ToList();
                genelBilgiler.BelgeNo = FaturaEvrakNo;
                genelBilgiler.GenelTutar = brütToplam.ToString();
                genelBilgiler.Toplamİskonto = toplamİskonto.ToString();
                genelBilgiler.ToplamKdv = kdvToplam.ToString();

                var genelBilgiJson = JsonConvert.SerializeObject(genelBilgiler);


                if (FişYazılsınmı)
                {
                    Task.Run(() => { TcpClientHelper.SendTcpRequest(ayar.TermalYazıcıIpAdresi, 5000, "FIS_YAZDIR@" + genelBilgiJson); });
                }




            }
            catch (Exception ex)
            {
                res.status = 0;
                res.message = "Fiş Kapatılırken Hata Oluştu :" + ex.Message;
                return Json(res);
            }



            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);


        }

        public IActionResult AyarGetir()
        {
            JsonResponseModel res = new JsonResponseModel();
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {
                res.status = 1;
                res.message = "İşlem Başarılı";
                res.data = _sıcakSatışAyarRepository.Get(o => o.UserId == "65884dec-abf8-43a9-b52e-8065e20aea5a");
                return Json(res);
            }

            res.status = 1;
            res.message = "İşlem Başarılı";
            res.data = _sıcakSatışAyarRepository.Get(o => o.UserId == userId);
            return Json(res);
        }
        public async Task<IActionResult> AyarKaydet(int HızlıButonProfilId, string CariKodu, string TermalYazıcıIpAdresi, string KrediKasaKodu, string NakitKasaKodu, string RivaDbYolu, string RivaKullancıAdı, string RivaŞifre)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            SıcakSatışAyar entity = new SıcakSatışAyar();
            var userAyar = _sıcakSatışAyarRepository.Get(o => o.UserId == userId);
            if (userAyar == null)
            {
                entity.UserId = userId;
                var addedEntity = _sıcakSatışAyarRepository.Add(entity);
                userAyar = addedEntity;
            }
            entity = userAyar;
            entity.UserId = userId;
            entity.HızlıButonProfilId = HızlıButonProfilId;
            entity.CariKodu = CariKodu;
            entity.TermalYazıcıIpAdresi = TermalYazıcıIpAdresi;
            entity.NakitKasaKodu = NakitKasaKodu;
            entity.KrediKasaKodu = KrediKasaKodu;
            entity.RivaDbYolu = RivaDbYolu;
            entity.RivaPass = RivaŞifre;
            entity.RivaUser = RivaKullancıAdı;

            _sıcakSatışAyarRepository.Update(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
        public IActionResult SıcakSatış()
        {
            //var x = GetLastFaturaNo();
            //var y = 1567.ToString().PadLeft(11, '0');

            //var x = FaturaGir(
            //     3701,
            //     5000,
            //     3,
            //     3,
            //     5000
            //     );

            //var userId = _userManager.GetUserId(HttpContext.User);
            //if (userId == null)
            //{
            //    return RedirectToAction("/Account/Login");
            //}

            SıcakSatışViewModel model = new SıcakSatışViewModel();
            model.SıcakSatışButonProfils = _sıcakSatışButonProfilRepository.GetAll();
            return View(model);
        }
        public IActionResult FaturaGörünüm(string EvrakNo)
        {
            FaturaGörünümViewModel model = new FaturaGörünümViewModel();
            var faturaBaşlık = GetFaturaBaşlıkByEvrakNo(EvrakNo).FirstOrDefault();
            var cari = GetCari(faturaBaşlık.FT_CARI_ID).FirstOrDefault();
            var faturaDetayları = GetFaturaDetayByFaturaId(faturaBaşlık.FT_ID.ToString());
            model.FaturaBaşlık = faturaBaşlık;
            model.RivaCari = cari;
            model.FaturaDetayDtos = faturaDetayları;

            return View(model);
        }
        public IActionResult FaturalarInfınty(int curPage, string EvrakNo, string CariAdı, DateTime StartDate, DateTime EndDate)
        {
            InfinityResponse<FaturaDto> res = new InfinityResponse<FaturaDto>();
            res.Data = FaturalarInfinify(curPage, EvrakNo, CariAdı, StartDate, EndDate);
            res.HasMore = true;

            return Json(res);
        }



        public IActionResult CarilerInfinity(int curPage, string[] CariIds)
        {
            InfinityResponse<RivaCari> res = new InfinityResponse<RivaCari>();
            res.Data = CarileriGetir(curPage, CariIds);
            res.HasMore = true;

            return Json(res);
        }
        public IActionResult CariHareketler(int CariId)
        {
            var cari = GetCari(CariId).FirstOrDefault();
            CariHareketlerViewModel model = new CariHareketlerViewModel();
            model.rivaCari = cari;
            model.cariHareket = GetCariHareket(CariId);
            return View(model);
        }
        public IActionResult CariHareketlerInfınıty(int curPage, int CariId, DateTime StartDate, DateTime EndDate)
        {
            InfinityResponse<RivaCariHareket> res = new InfinityResponse<RivaCariHareket>();
            res.Data = GetCariHareketInfınıty(curPage, CariId, StartDate, EndDate);
            res.HasMore = true;

            return Json(res);
        }


        public IActionResult StokBarkodEşle(string StokId, string Barkod)
        {
            using (FbConnection connection = new FbConnection(_connectionString))
            {
                connection.Open();

                // Güncelleme işlemi
                string updateQuery = $@"
                                UPDATE STOK a
                                SET 
                                    a.SK_OLCU1_BARKOD = @Barkod
                                WHERE
                                    a.SK_ID = @Kod
                                    ";
                using (FbCommand updateCmd = new FbCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Kod", StokId);
                    updateCmd.Parameters.AddWithValue("@Barkod", Barkod);
                    updateCmd.ExecuteNonQuery();
                }
            }
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult CariAra(string Aranan)
        {
            JsonResponseModel res = new JsonResponseModel();
            if (String.IsNullOrEmpty(Aranan))
            {

                res.status = 1;
                res.message = "Aranan İçerik Bulunamadı";
                res.data = null;
                return Json(res);
            }

            res.status = 1;
            res.message = "İşlem Başarılı";
            res.data = GetCariByString(Aranan);
            return Json(res);
        }


        public IActionResult Stoklar()
        {
            return View();
        }

        public IActionResult StokHareketler(int Id)
        {
            RivaStokHareketViewModel model = new RivaStokHareketViewModel();

            model.StokHarekets = StokHareketGetir(Id).ToList();

            return View(model);
        }
        public IActionResult StoklarInfinity(int curPage, string StokKodu, string StokAdı)
        {
            InfinityResponse<RivaStok> res = new InfinityResponse<RivaStok>();
            res.Data = GetAllStokInfınıty(StokKodu, StokAdı, curPage);
            res.HasMore = true;
            return Json(res);
        }

        public IActionResult Raporlar()
        {

            return View();
        }

        public IActionResult TarihAralıklıStokRaporu()
        {



            return View();
        }
        public IActionResult TarihAralıklıStokRaporuInfınıty(int curPage, int[] StokIds, int[] CariIds, DateTime StartDate, DateTime EndDate)
        {
            curPage = curPage == 0 ? 1 : curPage;
            var x = FaturalaIdLeriGetir(StokIds, CariIds);
            InfinityResponse<FaturaDto> res = new InfinityResponse<FaturaDto>();
            res.Data = FaturalarSeçili(curPage, StartDate, EndDate, x.ToArray());
            res.Data2 = FaturalaStokSonuçGetir(x.ToArray());
            res.HasMore = true;
            return Json(res);
        }
        public IActionResult CariHareketYazdır(DateTime StartDate, DateTime EndDate, int CariId, bool Detaylımı)
        {
            CariHarehetYazdırViewModel model = new CariHarehetYazdırViewModel();
            model.Cari = GetCari(CariId).FirstOrDefault();
            model.CariHareketler = GetCariHareket(CariId).Where(o => o.CH_ISLEM_TARIHI <= EndDate && o.CH_ISLEM_TARIHI >= StartDate).ToList();
            model.StartDate = StartDate;
            model.EndDate = EndDate;
            model.Detaylımı = Detaylımı;

            if (Detaylımı == true)
            {
                model.RivaFaturas = GetFaturalarByCariId(CariId);
                if (model.RivaFaturas.Count() > 0)
                {
                    model.RivaFaturaSatırs = GetFaturaDetayByMulFaturaId(model.RivaFaturas.Select(o => o.FT_ID.ToString()).ToArray());
                }
            }

            return View(model);
        }

        public IActionResult FaturaYazdır(string EvrakNo)
        {
            FaturaYazdırViewModel model = new FaturaYazdırViewModel();
            model.RivaFatura = GetFaturaBaşlıkByEvrakNo(EvrakNo).FirstOrDefault();
            model.RivaFaturaSatırs = GetFaturaDetayByFaturaId(model.RivaFatura.FT_ID.ToString());
            model.Cari = GetCari(model.RivaFatura.FT_CARI_ID).FirstOrDefault();

            return View(model);
        }

        //FaturaYazdırViewModel

    }
    public class TcpClientHelper
    {
        public static async Task SendTcpRequest(string serverIp, int port, string message)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(serverIp, port);
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    await stream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
