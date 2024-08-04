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
    public interface ICariRepository : IEntityRepositoryBase<Cari>
    {
        List<Cari> GetAllIncluded(Expression<Func<Cari, bool>> filter = null);
        List<Cari> GetAllIncludedPagination(Expression<Func<Cari, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Cari, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
