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
    public interface IKareKodBildirimStokMTMRepository : IEntityRepositoryBase<KareKodBildirimStokMTM>
    {
        List<KareKodBildirimStokMTM> GetAllIncluded(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null);
        List<KareKodBildirimStokMTM> GetAllIncludedPagination(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
