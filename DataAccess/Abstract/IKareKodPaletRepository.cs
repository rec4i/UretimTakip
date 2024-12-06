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
    public interface IKareKodPaletRepository : IEntityRepositoryBase<KareKodPalet>
    {
        List<KareKodPalet> GetAllIncluded(Expression<Func<KareKodPalet, bool>> filter = null);
        List<KareKodPalet> GetAllIncludedPagination(Expression<Func<KareKodPalet, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodPalet, bool>> filter = null, string offset = null, string limit = null, string search = null);
        KareKodPalet GetMax(Expression<Func<KareKodPalet, bool>> filter = null);

    }
}
