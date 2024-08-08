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
    public interface IDosyaRepository : IEntityRepositoryBase<Dosya>
    {
        List<Dosya> GetAllIncluded(Expression<Func<Dosya, bool>> filter = null);
        List<Dosya> GetAllIncludedPagination(Expression<Func<Dosya, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Dosya, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
