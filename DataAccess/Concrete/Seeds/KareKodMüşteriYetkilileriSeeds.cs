using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class KareKodMüşteriYetkilileriSeeds
    {
        public static void KareKodMüşteriYetkilileriSeed(this ModelBuilder modelBuilder)
        {
            var sideBarMenuItems = new List<KareKodMüşteriYetkilileri>
            {
                //Ayarlar
                new KareKodMüşteriYetkilileri{Id=1,KareKodMüşteriId=1,AdSoyad="Mehmet KARTAL",Email= "m.kartal@selcukecza.com.tr",Phone = "5309398848"},
                new KareKodMüşteriYetkilileri{Id=2,KareKodMüşteriId=1,AdSoyad="Umut Bey",Email= "merkezmalkabul@selcukecza.com.tr",Phone = "5439473452"},
                new KareKodMüşteriYetkilileri{Id=3,KareKodMüşteriId=1,AdSoyad="10",Email= "SİSTEMDEN",Phone = "asdasdasdasd"},
                new KareKodMüşteriYetkilileri{Id=4,KareKodMüşteriId=1,AdSoyad="10",Email= "SİSTEMDEN",Phone = "asdasdasdasd"},
                new KareKodMüşteriYetkilileri{Id=5,KareKodMüşteriId=1,AdSoyad="10",Email= "SİSTEMDEN",Phone = "asdasdasdasd"},
            };

            modelBuilder.Entity<KareKodMüşteriYetkilileri>().HasData(sideBarMenuItems);
        }
    }
}
