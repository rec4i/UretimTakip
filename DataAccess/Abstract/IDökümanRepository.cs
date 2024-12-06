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
    public interface IDökümanRepository : IEntityRepositoryBase<Döküman>
    {
        List<Döküman> GetAllIncluded(Expression<Func<Döküman, bool>> filter = null);
        List<Döküman> GetAllIncludedPagination(Expression<Func<Döküman, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Döküman, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
