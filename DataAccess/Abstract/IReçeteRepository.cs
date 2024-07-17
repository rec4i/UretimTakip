using Core.DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReçeteRepository : IEntityRepositoryBase<Reçete>
    {
        List<Reçete> GetAllIncluded(Expression<Func<Reçete, bool>> filter = null);
        List<Reçete> GetAllIncludedPagination(Expression<Func<Reçete, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Reçete, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
