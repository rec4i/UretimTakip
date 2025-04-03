using Entities.Concrete.OtherEntities;

namespace WebIU.Models.EkranTasarımViewModels
{
    public class ButtonEkleViewModel
    {
        public int ParentId { get; set; }
        public int ProfilId { get; set; }

        public SıcakSatışHızlıButon? Buton { get; set; }
    }
}
