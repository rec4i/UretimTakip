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
    public interface IBlokBilgiRepository : IEntityRepositoryBase<BlokBilgi>
    {
        List<BlokBilgi> GetAllIncluded(Expression<Func<BlokBilgi, bool>> filter = null);
        List<BlokBilgi> GetAllIncludedPagination(Expression<Func<BlokBilgi, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<BlokBilgi, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
