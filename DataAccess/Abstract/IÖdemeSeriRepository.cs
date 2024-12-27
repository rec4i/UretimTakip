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
    public interface IÖdemeSeriRepository : IEntityRepositoryBase<ÖdemeSeri>
    {
        List<ÖdemeSeri> GetAllIncluded(Expression<Func<ÖdemeSeri, bool>> filter = null);
        List<ÖdemeSeri> GetAllIncludedPagination(Expression<Func<ÖdemeSeri, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<ÖdemeSeri, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
