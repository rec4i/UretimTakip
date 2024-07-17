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
    public interface IIşRepository : IEntityRepositoryBase<Iş>
    {
        List<Iş> GetAllIncluded(Expression<Func<Iş, bool>> filter = null);
        List<Iş> GetAllIncludedPagination(Expression<Func<Iş, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Iş, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
