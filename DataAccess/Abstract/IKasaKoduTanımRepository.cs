﻿using Core.DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IKasaKoduTanımRepository : IEntityRepositoryBase<KasaKoduTanım>
    {
        List<KasaKoduTanım> GetAllIncluded(Expression<Func<KasaKoduTanım, bool>> filter = null);
        List<KasaKoduTanım> GetAllIncludedPagination(Expression<Func<KasaKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KasaKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
