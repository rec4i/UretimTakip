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
    public interface IStokRepository : IEntityRepositoryBase<Stok>
    {
        List<Stok> GetAllIncluded(Expression<Func<Stok, bool>> filter = null);
        List<Stok> GetAllIncludedPagination(Expression<Func<Stok, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Stok, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
