using Entities.Concrete.BaseEntities;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class EkipmanBakım : BaseEntity
    {

        public int BakımPeriyotFrekansı { get; set; }

        //4 Yıllık
        //3 Aylık
        //2 Günlük
        //1 Saatlik
        public int BakımPeriyotTipi { get; set; }


        public int EkipmanId { get; set; }
        public Ekipman Ekipman { get; set; }

    }
}
