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

namespace WebIU.Controllers
{
    public class RivaController : Controller
    {
        private string _connectionString = @"Server=localhost;Database=C:\Program Files (x86)\Riva\Entegra\Database\F5YAZILIM.SRV;User=SYSDBA;Password=masterkey;Charset=NONE;";
        #region Models 
        public class CariHareketlerViewModel
        {
            public RivaCari rivaCari { get; set; }
            public List<RivaCariHareket> cariHareket { get; set; }
        }
        #endregion
        #region Entites 
        public class InfinityResponse<T>
        {
            public List<T> Data { get; set; }
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

        #endregion

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cariler()
        {
            return View();
        }


        #region SqlSorguları
        //public IEnumerable<RivaFatura> GetFaturalar()
        //{
        //    using (IDbConnection db = new SqlConnection(_connectionString))
        //    {
        //        string query = @"
        //        SELECT r.FT_ID, r.FT_EVRAK_TIPI, r.FT_EVRAK_NO, r.FT_CARI_ID, r.FT_UNVAN,
        //               r.FT_ADRES, r.FT_ILCE, r.FT_IL, r.FT_POSTA_KODU, r.FT_VERGI_DAIRESI,
        //               r.FT_VERGI_NUMARASI, r.FT_BABA_ADI, r.FT_DOGUM_YERI, r.FT_DOGUM_TARIHI,
        //               r.FT_BAGKUR_DAIRESI, r.FT_BAGKUR_NUMARASI, r.FT_TC_KIMLIK_NUMARASI,
        //               r.FT_ACIKLAMA, r.FT_TIP, r.FT_TARIH, r.FT_ZAMAN, r.FT_VADE_TARIHI,
        //               r.FT_KDV_VADE_TARIHI, r.FT_TESLIM_TARIHI, r.FT_LISTE_FIYATI, r.FT_DOVIZ_ID,
        //               r.FT_DOVIZ_KUR_TARIHI, r.FT_DOVIZ_TUTAR, r.FT_DEPO_ID, r.FT_PLASIYER_ID,
        //               r.FT_BRUT_TOPLAM, r.FT_MAL_FAZLASI_ISK, r.FT_SATIR_ISK_TOPLAMI,
        //               r.FT_GENEL_ISK_MATRAHI, r.FT_GENEL_ISK_TOPLAMI, r.FT_MUS_STOPAJ,
        //               r.FT_MUS_FON, r.FT_MUS_BORSA, r.FT_MUS_MERA, r.FT_MUS_BAGKUR,
        //               r.FT_MUS_KES_TOPLAMI, r.FT_KALEM_SAYISI, r.FT_TOPLAM_MIKTAR,
        //               r.FT_TOPLAM_AGIRLIK, r.FT_NAKLIYE_TUTARI, r.FT_NAKLIYE_TUTARI_KDV,
        //               r.FT_EK_MALIYET_TOPLAMI, r.FT_VADE_FARKI, r.FT_VADE_FARKI_KDV,
        //               r.FT_KDV_TOPLAMI, r.FT_KDV_TOPLAMI_YUV, r.FT_GENEL_TOPLAM,
        //               r.FT_GENEL_TOPLAM_YUV, r.FT_KDV_DAHIL, r.FT_KDV_ISK_ONCE_DUS,
        //               r.FT_KDV_MAL_FAZLASI, r.FT_KDV_MAL_FAZLA_NET, r.FT_CARIYE_KAYIT,
        //               r.FT_PESINAT_AYRILSIN, r.FT_STOKLARA_KAYIT, r.FT_STOK_IRS_TARIHI,
        //               r.FT_STOK_MAL_EK_MALIYET, r.FT_STOK_MAL_NAKLIYE, r.FT_KAPATILMIS,
        //               r.FT_KARSILANMIS, r.FT_NOTLAR, r.FT_SIS_01, r.FT_SIS_02, r.FT_SIS_03,
        //               r.FT_GIS_01, r.FT_GIS_02, r.FT_GIS_03, r.FT_EMT_01, r.FT_EMT_02,
        //               r.FT_EMT_03, r.FT_EMK_01, r.FT_EMK_02, r.FT_EMK_03
        //        FROM FATURA r";

        //        //return db.Query<Fatura>(query);
        //    }
        //}
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
        public List<RivaCari> CarileriGetir(int pageNumber, string CariKodu, string CariAdı)
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

 WHERE 
          r.CA_UNVAN LIKE '%{CariAdı}%' 
        AND r.CA_KOD LIKE '%{CariKodu}%'

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
        #endregion



        public IActionResult FaturaGörünüm(int EvrakNo)
        {




            return View();
        }

        public IActionResult CarilerInfinity(int curPage, string CariAdı, string CariKodu)
        {
            InfinityResponse<RivaCari> res = new InfinityResponse<RivaCari>();
            res.Data = CarileriGetir(curPage, CariKodu, CariAdı);
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
    }
}
