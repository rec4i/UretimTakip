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
    public interface IFaturaSeriRepository : IEntityRepositoryBase<FaturaSeri>
    {
        List<FaturaSeri> GetAllIncluded(Expression<Func<FaturaSeri, bool>> filter = null);
        List<FaturaSeri> GetAllIncludedPagination(Expression<Func<FaturaSeri, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<FaturaSeri, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
