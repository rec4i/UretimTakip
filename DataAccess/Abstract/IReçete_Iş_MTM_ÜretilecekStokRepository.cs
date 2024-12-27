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
    public interface IReçete_Iş_MTM_ÜretilecekStokRepository : IEntityRepositoryBase<Reçete_Iş_MTM_ÜretilecekStok>
    {
        List<Reçete_Iş_MTM_ÜretilecekStok> GetAllIncluded(Expression<Func<Reçete_Iş_MTM_ÜretilecekStok, bool>> filter = null);
        List<Reçete_Iş_MTM_ÜretilecekStok> GetAllIncludedPagination(Expression<Func<Reçete_Iş_MTM_ÜretilecekStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<Reçete_Iş_MTM_ÜretilecekStok, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
