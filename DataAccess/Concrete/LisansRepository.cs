using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class LisansRepository : EntityReposiyoryBase<Lisans, AppIdentityDbContext>, ILisansRepository
    {
        public List<Lisans> GetAllIncluded(Expression<Func<Lisans, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Lisans>().Where("IsDeleted == false")
                    .ToList().ToList()
                    : context.Set<Lisans>().Where("IsDeleted == false").Where(filter)
                    .ToList();
                return entities;
            }
        }

        public List<Lisans> GetAllIncludedPagination(Expression<Func<Lisans, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Lisans>().Where("IsDeleted == false")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Lisans>().Where("IsDeleted == false").Where(filter)


                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Lisans, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Lisans>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Lisans>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
