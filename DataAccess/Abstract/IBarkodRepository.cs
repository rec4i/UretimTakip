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
    public interface IBarkodRepository : IEntityRepositoryBase<Barkod>
    {
        List<Barkod> GetAllIncluded(Expression<Func<Barkod, bool>> filter = null);
        List<Barkod> GetAllIncludedPagination(Expression<Func<Barkod, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Barkod, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
