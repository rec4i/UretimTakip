using Core.DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDepoRepository : IEntityRepositoryBase<Depo>
    {
        List<Depo> GetAllIncluded(Expression<Func<Depo, bool>> filter = null);
        List<Depo> GetAllIncludedPagination(Expression<Func<Depo, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Depo, bool>> filter = null, string offset = null, string limit = null, string search = null);

    }
}
