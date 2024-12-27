using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class CariDetayViewModel
    {
        public Cari Cari { get; set; }

        public List<ÖdemeSeri> ÖdemeSeris { get; set; }

        public string KasaKoduTanım { get; set; }

    }
}
