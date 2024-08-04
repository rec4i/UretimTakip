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
    public interface IStokKoduTanımRepository : IEntityRepositoryBase<StokKoduTanım>
    {
        List<StokKoduTanım> GetAllIncluded(Expression<Func<StokKoduTanım, bool>> filter = null);
        List<StokKoduTanım> GetAllIncludedPagination(Expression<Func<StokKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<StokKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);

    }
}
