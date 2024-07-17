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
    public interface ITezgah_Iş_MTMReposiyory : IEntityRepositoryBase<Tezgah_Iş_MTM>
    {
        List<Tezgah_Iş_MTM> GetAllIncluded(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null);
        List<Tezgah_Iş_MTM> GetAllIncludedPagination(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null);


    }
}
