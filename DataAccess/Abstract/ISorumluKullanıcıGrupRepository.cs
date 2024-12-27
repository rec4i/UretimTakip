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
    public interface ISorumluKullanıcıGrupRepository : IEntityRepositoryBase<SorumluKullanıcıGrup>
    {
        List<SorumluKullanıcıGrup> GetAllIncluded(Expression<Func<SorumluKullanıcıGrup, bool>> filter = null);
        List<SorumluKullanıcıGrup> GetAllIncludedPagination(Expression<Func<SorumluKullanıcıGrup, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<SorumluKullanıcıGrup, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
