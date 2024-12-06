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
    public interface IKareKodBildirimEmriRepository : IEntityRepositoryBase<KareKodBildirimEmri>
    {
        List<KareKodBildirimEmri> GetAllIncluded(Expression<Func<KareKodBildirimEmri, bool>> filter = null);
        List<KareKodBildirimEmri> GetAllIncludedPagination(Expression<Func<KareKodBildirimEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodBildirimEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
