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
    public interface IKareKodAnaUrunRepository : IEntityRepositoryBase<KareKodAnaUrun>
    {
        List<KareKodAnaUrun> GetAllIncluded(Expression<Func<KareKodAnaUrun, bool>> filter = null);
        List<KareKodAnaUrun> GetAllIncludedPagination(Expression<Func<KareKodAnaUrun, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodAnaUrun, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}