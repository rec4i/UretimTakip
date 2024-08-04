using Core.DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProgramŞirketGrupRepository : IEntityRepositoryBase<ProgramŞirketGrup>
    {
        Task<int> GetUserGroupId();
        List<ProgramŞirketGrup> GetAllIncluded(Expression<Func<ProgramŞirketGrup, bool>> filter = null);
        List<ProgramŞirketGrup> GetAllIncludedPagination(Expression<Func<ProgramŞirketGrup, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<ProgramŞirketGrup, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
