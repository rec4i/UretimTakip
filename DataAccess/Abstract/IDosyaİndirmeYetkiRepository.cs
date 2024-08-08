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
    public interface IDosyaİndirmeYetkiRepository : IEntityRepositoryBase<DosyaİndirmeYetki>
    {
        List<DosyaİndirmeYetki> GetAllIncluded(Expression<Func<DosyaİndirmeYetki, bool>> filter = null);
        List<DosyaİndirmeYetki> GetAllIncludedPagination(Expression<Func<DosyaİndirmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DosyaİndirmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
