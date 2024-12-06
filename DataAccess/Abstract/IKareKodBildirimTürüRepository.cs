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
    public interface IKareKodBildirimTürüRepository : IEntityRepositoryBase<KareKodBildirimTürü>
    {
        List<KareKodBildirimTürü> GetAllIncluded(Expression<Func<KareKodBildirimTürü, bool>> filter = null);
        List<KareKodBildirimTürü> GetAllIncludedPagination(Expression<Func<KareKodBildirimTürü, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodBildirimTürü, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
