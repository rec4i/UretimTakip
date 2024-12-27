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
    public interface IİşEmriDurumRepository : IEntityRepositoryBase<İşEmriDurum>
    {
        List<İşEmriDurum> GetAllIncluded(Expression<Func<İşEmriDurum, bool>> filter = null);
        List<İşEmriDurum> GetAllIncludedPagination(Expression<Func<İşEmriDurum, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<İşEmriDurum, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
