using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class BirimSeed
    {
        public static void BirimiSeeds(this ModelBuilder modelBuilder)
        {
            var countries = new List<Birim>
            {
                new Birim { BirimKodu = "ADET", DönüşümKodu = "NIU", DönüşümAçıklama = "ADET",Id = 1 },
                new Birim { BirimKodu = "KG", DönüşümKodu = "KGM", DönüşümAçıklama = "KİLOGRAM", Id = 2 },
                new Birim { BirimKodu = "GR", DönüşümKodu = "GRM", DönüşümAçıklama = "GRAM", Id = 3 },
                new Birim { BirimKodu = "M", DönüşümKodu = "MTR", DönüşümAçıklama = "METRE", Id = 4 },
                new Birim { BirimKodu = "LİTRE", DönüşümKodu = "LTR", DönüşümAçıklama = "LİTRE", Id = 5 },
                new Birim { BirimKodu = "PA", DönüşümKodu = "PA", DönüşümAçıklama = "PAKET (Packet)", Id = 6 },
                new Birim { BirimKodu = "PK", DönüşümKodu = "PK", DönüşümAçıklama = "PAKET (Pack)", Id = 7 },
                new Birim { BirimKodu = "KUTU", DönüşümKodu = "BX", DönüşümAçıklama = "KUTU", Id = 8 },
                new Birim { BirimKodu = "METRE", DönüşümKodu = "MTR", DönüşümAçıklama = "METRE", Id = 9 },
                new Birim { BirimKodu = "CM", DönüşümKodu = "CMT", DönüşümAçıklama = "SANTİMETRE",Id = 10 },
                new Birim { BirimKodu = "M3", DönüşümKodu = "MTQ", DönüşümAçıklama = "METREKÜB", Id = 11 },
                new Birim { BirimKodu = "M2", DönüşümKodu = "MTK", DönüşümAçıklama = "METREKARE", Id = 12 },
                new Birim { BirimKodu = "RULO", DönüşümKodu = "ROLL", DönüşümAçıklama = "RULO", Id = 13 },
                new Birim { BirimKodu = "SET", DönüşümKodu = "SET", DönüşümAçıklama = "SET", Id = 14 },
                new Birim { BirimKodu = "CM3", DönüşümKodu = "CMQ", DönüşümAçıklama = "SANTİMETREKÜB", Id = 15 }
            };
            modelBuilder.Entity<Birim>().HasData(countries);

        }
    }
}
