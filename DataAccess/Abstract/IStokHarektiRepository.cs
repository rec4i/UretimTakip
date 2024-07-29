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
    public interface IStokHarektiRepository : IEntityRepositoryBase<StokHareket>
    {
        List<StokHareket> GetAllIncluded(Expression<Func<StokHareket, bool>> filter = null);
        List<StokHareket> GetAllIncludedPagination(Expression<Func<StokHareket, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<StokHareket, bool>> filter = null, string offset = null, string limit = null, string search = null);

    }
}
