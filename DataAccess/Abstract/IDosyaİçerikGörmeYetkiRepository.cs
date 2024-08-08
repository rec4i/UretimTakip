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
    public interface IDosyaİçerikGörmeYetkiRepository : IEntityRepositoryBase<DosyaİçerikGörmeYetki>
    {
        List<DosyaİçerikGörmeYetki> GetAllIncluded(Expression<Func<DosyaİçerikGörmeYetki, bool>> filter = null);
        List<DosyaİçerikGörmeYetki> GetAllIncludedPagination(Expression<Func<DosyaİçerikGörmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DosyaİçerikGörmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
