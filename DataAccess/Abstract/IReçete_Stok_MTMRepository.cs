using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IReçete_Stok_MTMRepository : IEntityRepositoryBase<Reçete_Stok_MTM>
    {
        List<Reçete_Stok_MTM> GetAllIncluded(Expression<Func<Reçete_Stok_MTM, bool>> filter = null);
        List<Reçete_Stok_MTM> GetAllIncludedPagination(Expression<Func<Reçete_Stok_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Reçete_Stok_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
