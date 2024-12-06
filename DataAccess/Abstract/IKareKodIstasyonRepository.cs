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
    public interface IKareKodIstasyonRepository : IEntityRepositoryBase<KareKodIstasyon>
    {
        List<KareKodIstasyon> GetAllIncluded(Expression<Func<KareKodIstasyon, bool>> filter = null);
        List<KareKodIstasyon> GetAllIncludedPagination(Expression<Func<KareKodIstasyon, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodIstasyon, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
