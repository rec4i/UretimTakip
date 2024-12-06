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
    public interface ICariHareketRepository : IEntityRepositoryBase<CariHareket>
    {
        List<CariHareket> GetAllIncluded(Expression<Func<CariHareket, bool>> filter = null);
        List<CariHareket> GetAllIncludedPagination(Expression<Func<CariHareket, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<CariHareket, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
