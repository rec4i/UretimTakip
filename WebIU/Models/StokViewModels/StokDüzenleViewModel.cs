using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class StokDüzenleViewModel
    {
        public Stok Stok { get; set; }

        public List<Birim> Birims { get; set; }
        public List<Depo> Depos { get; set; }

    }
}
