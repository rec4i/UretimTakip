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
    public interface ITezgahRepository : IEntityRepositoryBase<Tezgah>
    {
        List<Tezgah> GetAllIncluded(Expression<Func<Tezgah, bool>> filter = null);
        List<Tezgah> GetAllIncludedPagination(Expression<Func<Tezgah, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Tezgah, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
