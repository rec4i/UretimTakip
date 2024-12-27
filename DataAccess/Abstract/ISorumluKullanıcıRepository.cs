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
    public interface ISorumluKullanıcıRepository : IEntityRepositoryBase<SorumluKullanıcı>
    {
        List<SorumluKullanıcı> GetAllIncluded(Expression<Func<SorumluKullanıcı, bool>> filter = null);
        List<SorumluKullanıcı> GetAllIncludedPagination(Expression<Func<SorumluKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<SorumluKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
