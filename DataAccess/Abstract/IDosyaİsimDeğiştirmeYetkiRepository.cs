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
    public interface IDosyaİsimDeğiştirmeYetkiRepository : IEntityRepositoryBase<DosyaİsimDeğiştirmeYetki>
    {
        List<DosyaİsimDeğiştirmeYetki> GetAllIncluded(Expression<Func<DosyaİsimDeğiştirmeYetki, bool>> filter = null);
        List<DosyaİsimDeğiştirmeYetki> GetAllIncludedPagination(Expression<Func<DosyaİsimDeğiştirmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DosyaİsimDeğiştirmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
