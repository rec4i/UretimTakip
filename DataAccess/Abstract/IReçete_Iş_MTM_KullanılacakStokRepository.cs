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
    public interface IReçete_Iş_MTM_KullanılacakStokRepository : IEntityRepositoryBase<Reçete_Iş_MTM_KullanılacakStok>
    {
        List<Reçete_Iş_MTM_KullanılacakStok> GetAllIncluded(Expression<Func<Reçete_Iş_MTM_KullanılacakStok, bool>> filter = null);
        List<Reçete_Iş_MTM_KullanılacakStok> GetAllIncludedPagination(Expression<Func<Reçete_Iş_MTM_KullanılacakStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Reçete_Iş_MTM_KullanılacakStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
