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
    public interface IFaturaBaslıkRepository : IEntityRepositoryBase<FaturaBaslık>
    {
        List<FaturaBaslık> GetAllIncluded(Expression<Func<FaturaBaslık, bool>> filter = null);
        List<FaturaBaslık> GetAllIncludedPagination(Expression<Func<FaturaBaslık, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<FaturaBaslık, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
