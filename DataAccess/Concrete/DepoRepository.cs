using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;


namespace DataAccess.Concrete
{
    public class DepoRepository : EntityReposiyoryBase<Depo, AppIdentityDbContext>, IDepoRepository
    {
        public List<Depo> GetAllIncluded(Expression<Func<Depo, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Depo>().Where("IsDeleted == false")
                .ToList().ToList()
                    : context.Set<Depo>().Where("IsDeleted == false").Where(filter)
                .ToList();
                return entities;
            }
        }

        public List<Depo> GetAllIncludedPagination(Expression<Func<Depo, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Depo>().Where("IsDeleted == false")
                      .Where(o =>
                    search == null ? o.DepoAdı == o.DepoAdı :
                    o.DepoAdı.ToLower().Contains(search.ToLower())
                    )


               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Depo>().Where("IsDeleted == false").Where(filter)
                   .Where(o =>
                    search == null ? o.DepoAdı == o.DepoAdı :
                    o.DepoAdı.ToLower().Contains(search.ToLower())
                    )

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Depo, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Depo>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Depo>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

    }
}
