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
    internal interface IDökümanAlanRepository : IEntityRepositoryBase<DökümanAlan>
    {
        List<DökümanAlan> GetAllIncluded(Expression<Func<DökümanAlan, bool>> filter = null);
        List<DökümanAlan> GetAllIncludedPagination(Expression<Func<DökümanAlan, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DökümanAlan, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
