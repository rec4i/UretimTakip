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
    public interface IDosyaSilmeYetkiRepository : IEntityRepositoryBase<DosyaSilmeYetki>
    {
        List<DosyaSilmeYetki> GetAllIncluded(Expression<Func<DosyaSilmeYetki, bool>> filter = null);
        List<DosyaSilmeYetki> GetAllIncludedPagination(Expression<Func<DosyaSilmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DosyaSilmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
