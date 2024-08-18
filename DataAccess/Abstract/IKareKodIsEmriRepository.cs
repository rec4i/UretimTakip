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
    public interface IKareKodIsEmriRepository : IEntityRepositoryBase<KareKodIsEmri>
    {
        List<KareKodIsEmri> GetAllIncluded(Expression<Func<KareKodIsEmri, bool>> filter = null);
        List<KareKodIsEmri> GetAllIncludedPagination(Expression<Func<KareKodIsEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodIsEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
