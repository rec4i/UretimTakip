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
    public interface IKareKodIsEmriIstasyonMTMRepository : IEntityRepositoryBase<KareKodIsEmriIstasyonMTM>
    {
        List<KareKodIsEmriIstasyonMTM> GetAllIncluded(Expression<Func<KareKodIsEmriIstasyonMTM, bool>> filter = null);
        List<KareKodIsEmriIstasyonMTM> GetAllIncludedPagination(Expression<Func<KareKodIsEmriIstasyonMTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<KareKodIsEmriIstasyonMTM, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
