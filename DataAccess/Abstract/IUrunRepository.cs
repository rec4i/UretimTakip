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
    public interface IUrunRepository : IEntityRepositoryBase<Urun>
    {
        List<Urun> GetAllIncluded(Expression<Func<Urun, bool>> filter = null);
        List<Urun> GetAllIncludedPagination(Expression<Func<Urun, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Urun, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
