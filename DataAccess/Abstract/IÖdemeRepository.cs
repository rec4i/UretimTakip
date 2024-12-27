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
    public interface IÖdemeRepository : IEntityRepositoryBase<Ödeme>
    {
        List<Ödeme> GetAllIncluded(Expression<Func<Ödeme, bool>> filter = null);
        List<Ödeme> GetAllIncludedPagination(Expression<Func<Ödeme, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Ödeme, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
