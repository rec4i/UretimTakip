using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SorumluKullanıcıRepository : EntityReposiyoryBase<SorumluKullanıcı, AppIdentityDbContext>, ISorumluKullanıcıRepository
    {
        public List<SorumluKullanıcı> GetAllIncluded(Expression<Func<SorumluKullanıcı, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<SorumluKullanıcı>().Where("IsDeleted == false")
                    .Include("User")
                .ToList().ToList()
                    : context.Set<SorumluKullanıcı>().Where("IsDeleted == false").Where(filter)
                            .Include("User")
                .ToList();
                return entities;
            }
        }

        public List<SorumluKullanıcı> GetAllIncludedPagination(Expression<Func<SorumluKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<SorumluKullanıcı>().Where("IsDeleted == false")
                            .Include("User")


                .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<SorumluKullanıcı>().Where("IsDeleted == false").Where(filter)
                            .Include("User")
                .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<SorumluKullanıcı, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<SorumluKullanıcı>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<SorumluKullanıcı>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
