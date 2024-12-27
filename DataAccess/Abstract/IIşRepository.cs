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
    public interface IIşRepository : IEntityRepositoryBase<İş>
    {
        List<İş> GetAllIncluded(Expression<Func<İş, bool>> filter = null);
        List<İş> GetAllIncludedPagination(Expression<Func<İş, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<İş, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
