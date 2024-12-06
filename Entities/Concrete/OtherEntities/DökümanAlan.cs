using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class DökümanAlan : BaseEntity
    {
        public string DolduralacakAlanString { get; set; }
        public string? DefaultString { get; set; }







        //1 String
        //2 True/False
        //3 SelectBox
        public int AlanTipi { get; set; }



        public int DökümanId { get; set; }
        public Döküman Döküman { get; set; }


    }
}
