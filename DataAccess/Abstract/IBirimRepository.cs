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
    public interface IBirimRepository : IEntityRepositoryBase<Birim>
    {
        List<Birim> GetAllIncluded(Expression<Func<Birim, bool>> filter = null);
        List<Birim> GetAllIncludedPagination(Expression<Func<Birim, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Birim, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
