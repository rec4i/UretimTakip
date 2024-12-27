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
    public interface IDepoKoduTanımRepository : IEntityRepositoryBase<DepoKoduTanım>
    {
        List<DepoKoduTanım> GetAllIncluded(Expression<Func<DepoKoduTanım, bool>> filter = null);
        List<DepoKoduTanım> GetAllIncludedPagination(Expression<Func<DepoKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DepoKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
