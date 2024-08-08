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
    public interface IDosyaYetkiYetkiRepository : IEntityRepositoryBase<DosyaYetkiYetki>
    {
        List<DosyaYetkiYetki> GetAllIncluded(Expression<Func<DosyaYetkiYetki, bool>> filter = null);
        List<DosyaYetkiYetki> GetAllIncludedPagination(Expression<Func<DosyaYetkiYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<DosyaYetkiYetki, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
