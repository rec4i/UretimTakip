using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class KareKodMüşteriSeeds
    {
        public static void KareKodMüşteriSeed(this ModelBuilder modelBuilder)
        {
            var sideBarMenuItems = new List<KareKodMüşteri>
            {
                //Ayarlar
                new KareKodMüşteri{Id=1,Adı="SELÇUK ECZA DEPOSU A.Ş. ÜMRANİYE ŞUBESİ",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye Şubesi"},
                new KareKodMüşteri{Id=2,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},
                new KareKodMüşteri{Id=1,Adı="SELÇUK",GLN= "8699810014004",ToGLN="8699810000014",Adres ="Ümraniye"},

            };

            modelBuilder.Entity<KareKodMüşteri>().HasData(sideBarMenuItems);
        }
    }
}
