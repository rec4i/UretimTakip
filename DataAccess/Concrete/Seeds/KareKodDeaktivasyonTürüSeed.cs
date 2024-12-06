using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class KareKodDeaktivasyonTürüSeed
    {
        public static void KareKodDeaktivasyonTürüSeeds(this ModelBuilder modelBuilder)
        {
            var sideBarMenuItems = new List<KareKodDeaktivasyonTürü>
            {
                //Ayarlar
                new KareKodDeaktivasyonTürü{Id=1,DeaktivasyonKodu="10",Sebep= "SİSTEMDEN ÇIKARMA"},
                new KareKodDeaktivasyonTürü{Id=2,DeaktivasyonKodu="20",Sebep= "ÜRETİM FİRELERİ"},
                new KareKodDeaktivasyonTürü{Id=3,DeaktivasyonKodu="30",Sebep= "GERİ ÇEKME SEBEBİYLE İMHA"},
                new KareKodDeaktivasyonTürü{Id=4,DeaktivasyonKodu="40",Sebep= "MİAT SEBEBİYLE İMHA"},
                new KareKodDeaktivasyonTürü{Id=5,DeaktivasyonKodu="50",Sebep= "REVİZYON"},
            };

            modelBuilder.Entity<KareKodDeaktivasyonTürü>().HasData(sideBarMenuItems);
        }
    }
}
