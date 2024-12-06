using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    // TODO :Döküman Ekleme Ekranı Yapılacak Ve reposiyoryler oluşturalacak
    // TODO :Dökümanın Tablo Olan cinslerini bir daha düşün ne yapabiliriz

    public class Döküman : BaseEntity
    {
        public string Adı { get; set; }
        public string DosyaYolu { get; set; }
    }
}
