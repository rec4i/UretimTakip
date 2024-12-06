using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class KareKodBildirimTürüSeeds
    {
        public static void KareKodBildirimTürüSeed(this ModelBuilder modelBuilder)
        {
            var sideBarMenuItems = new List<KareKodBildirimTürü>
            {
                //Ayarlar
                new KareKodBildirimTürü{Id=1,BildirimTürü="Üretim",BildirimTürüKodu = "M"},
                new KareKodBildirimTürü{Id=2,BildirimTürü="Satış",BildirimTürüKodu = "S"},
                new KareKodBildirimTürü{Id=3,BildirimTürü="Satış Iptal",BildirimTürüKodu = "C"},
                new KareKodBildirimTürü{Id=4,BildirimTürü="Ihracat",BildirimTürüKodu = "X"},
                new KareKodBildirimTürü{Id=5,BildirimTürü="Ithalat",BildirimTürüKodu = "I"},
                new KareKodBildirimTürü{Id=6,BildirimTürü="Deaktivasyon",BildirimTürüKodu = "D"},
                new KareKodBildirimTürü{Id=7,BildirimTürü="Mal Alım",BildirimTürüKodu = "A"},
                new KareKodBildirimTürü{Id=8,BildirimTürü="Mal Iade",BildirimTürüKodu = "F"},
                new KareKodBildirimTürü{Id=9,BildirimTürü="Mal Devir",BildirimTürüKodu = "S"},
                new KareKodBildirimTürü{Id=10,BildirimTürü="Mal Devir Iptal",BildirimTürüKodu = "C"},
            };

            modelBuilder.Entity<KareKodBildirimTürü>().HasData(sideBarMenuItems);
        }
    }
}
