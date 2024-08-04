using Core.DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IŞantiyeRepository : IEntityRepositoryBase<Şantiye>
    {
        List<Şantiye> GetAllIncluded(Expression<Func<Şantiye, bool>> filter = null);
        List<Şantiye> GetAllIncludedPagination(Expression<Func<Şantiye, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Şantiye, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
