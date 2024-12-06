namespace WebIU.Models.FabrikaMakinaYönetimModels
{
    public class FırınViewModel
    {
        public bool FırınDurdurSayac { get; set; }
        public bool SogutmaBaslatSayac { get; set; }

        public bool FırınÇalışmaDurum { get; set; }
        public bool SogutmaCalısmaDurum { get; set; }



        public int BASST { get; set; }
        public int BASDK { get; set; }
        public int BITST { get; set; }
        public int BITDK { get; set; }



        public int SBASST { get; set; }
        public int SBASDK { get; set; }
        public int SBITST { get; set; }
        public int SBITDK { get; set; }



        public bool FırınBaslat { get; set; }
        public bool FırınKapat { get; set; }


        public bool SogutmaBaslat { get; set; }
        public bool SogutmaKapat { get; set; }


        public int FırınKapatmaSure { get; set; }
        public int FırınSogutmaSure { get; set; }


    }
}
