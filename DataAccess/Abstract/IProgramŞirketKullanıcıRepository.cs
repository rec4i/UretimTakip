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
    public interface IProgramŞirketKullanıcıRepository : IEntityRepositoryBase<ProgramŞirketKullanıcı>
    {
        List<ProgramŞirketKullanıcı> GetAllIncluded(Expression<Func<ProgramŞirketKullanıcı, bool>> filter = null);
        List<ProgramŞirketKullanıcı> GetAllIncludedPagination(Expression<Func<ProgramŞirketKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<ProgramŞirketKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null);
    }
}
