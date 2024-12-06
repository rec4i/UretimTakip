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
    public interface IKareKodStokRepository : IEntityRepositoryBase<KareKodStok>
    {
        List<KareKodStok> GetAllIncluded(Expression<Func<KareKodStok, bool>> filter = null);
        List<KareKodStok> GetAllIncludedPagination(Expression<Func<KareKodStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
