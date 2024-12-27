using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProgramŞirketGrupRepository : EntityReposiyoryBase<ProgramŞirketGrup, AppIdentityDbContext>, IProgramŞirketGrupRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public ProgramŞirketGrupRepository(IHttpContextAccessor httpContextAccessor, UserManager<AppIdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public List<ProgramŞirketGrup> GetAllIncluded(Expression<Func<ProgramŞirketGrup, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<ProgramŞirketGrup>().Where("IsDeleted == false")
                    .ToList().ToList()
                    : context.Set<ProgramŞirketGrup>().Where("IsDeleted == false").Where(filter)
                    .ToList();
                return entities;
            }
        }

        public List<ProgramŞirketGrup> GetAllIncludedPagination(Expression<Func<ProgramŞirketGrup, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<ProgramŞirketGrup>().Where("IsDeleted == false")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<ProgramŞirketGrup>().Where("IsDeleted == false").Where(filter)

                  .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<ProgramŞirketGrup, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<ProgramŞirketGrup>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<ProgramŞirketGrup>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

        public async Task<int> GetUserGroupId()
        {
            using (var context = new AppIdentityDbContext())
            {
                var userId = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                var res = context.Set<ProgramŞirketKullanıcı>().Where(o => o.UserId == userId.Id).FirstOrDefault().ProgramŞirketGrupId;

                return res;
            }
        }
    }
}
