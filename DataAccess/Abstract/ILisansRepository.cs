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
    public interface ILisansRepository : IEntityRepositoryBase<Lisans>
    {
        List<Lisans> GetAllIncluded(Expression<Func<Lisans, bool>> filter = null);
        List<Lisans> GetAllIncludedPagination(Expression<Func<Lisans, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Lisans, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
