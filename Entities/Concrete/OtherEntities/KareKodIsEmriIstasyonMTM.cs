﻿using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodIsEmriIstasyonMTM : BaseEntity
    {
        public int? KareKodIsEmriId { get; set; }

        public int? KareKodIstasyonId { get; set; }

    }
}