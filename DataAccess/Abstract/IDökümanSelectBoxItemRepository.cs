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
    public interface IDökümanSelectBoxItemRepository : IEntityRepositoryBase<DökümanSelectBoxItem>
    {
        List<DökümanSelectBoxItem> GetAllIncluded(Expression<Func<DökümanSelectBoxItem, bool>> filter = null);
        List<DökümanSelectBoxItem> GetAllIncludedPagination(Expression<Func<DökümanSelectBoxItem, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DökümanSelectBoxItem, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
