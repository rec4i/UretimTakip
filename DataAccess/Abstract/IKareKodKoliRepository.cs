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
    public interface IKareKodKoliRepository : IEntityRepositoryBase<KareKodKoli>
    {
        List<KareKodKoli> GetAllIncluded(Expression<Func<KareKodKoli, bool>> filter = null);
        List<KareKodKoli> GetAllIncludedPagination(Expression<Func<KareKodKoli, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodKoli, bool>> filter = null, string offset = null, string limit = null, string search = null);
        KareKodKoli GetLast(Expression<Func<KareKodKoli, bool>> filter = null);
        KareKodKoli GetMax(Expression<Func<KareKodKoli, bool>> filter = null);
    }
}
