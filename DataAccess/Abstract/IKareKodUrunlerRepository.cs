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
    public interface IKareKodUrunlerRepository : IEntityRepositoryBase<KareKodUrunler>
    {
        List<KareKodUrunler> GetAllIncluded(Expression<Func<KareKodUrunler, bool>> filter = null);
        KareKodUrunler GetLast(Expression<Func<KareKodUrunler, bool>> filter = null);
        List<KareKodUrunler> GetAllIncludedPagination(Expression<Func<KareKodUrunler, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodUrunler, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
