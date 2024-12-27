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
    public interface IKasaRepository : IEntityRepositoryBase<Kasa>
    {
        List<Kasa> GetAllIncluded(Expression<Func<Kasa, bool>> filter = null);
        List<Kasa> GetAllIncludedPagination(Expression<Func<Kasa, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Kasa, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
