using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IİşEmriRepository : IEntityRepositoryBase<İşEmri>
    {
        List<İşEmri> GetAllIncluded(Expression<Func<İşEmri, bool>> filter = null);
        List<İşEmri> GetAllIncludedPagination(Expression<Func<İşEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<İşEmri, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }

}
