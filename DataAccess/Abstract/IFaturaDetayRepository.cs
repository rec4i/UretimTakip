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
    public interface IFaturaDetayRepository : IEntityRepositoryBase<FaturaDetay>
    {
        List<FaturaDetay> GetAllIncluded(Expression<Func<FaturaDetay, bool>> filter = null);
        List<FaturaDetay> GetAllIncludedPagination(Expression<Func<FaturaDetay, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<FaturaDetay, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
