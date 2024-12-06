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
    public interface IKareKodDeaktivasyonTürüRepository : IEntityRepositoryBase<KareKodDeaktivasyonTürü>
    {
        List<KareKodDeaktivasyonTürü> GetAllIncluded(Expression<Func<KareKodDeaktivasyonTürü, bool>> filter = null);
        List<KareKodDeaktivasyonTürü> GetAllIncludedPagination(Expression<Func<KareKodDeaktivasyonTürü, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodDeaktivasyonTürü, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
