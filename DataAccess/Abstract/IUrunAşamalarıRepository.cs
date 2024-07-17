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
    public interface IUrunAşamalarıRepository : IEntityRepositoryBase<UrunAşamaları>
    {
        List<UrunAşamaları> GetAllIncluded(Expression<Func<UrunAşamaları, bool>> filter = null);
        List<UrunAşamaları> GetAllIncludedPagination(Expression<Func<UrunAşamaları, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<UrunAşamaları, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
