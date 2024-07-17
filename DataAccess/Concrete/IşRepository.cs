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
    public class IşRepository : EntityReposiyoryBase<Iş, AppIdentityDbContext>, IIşRepository
    {
        public List<Iş> GetAllIncluded(Expression<Func<Iş, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Iş>().Where("IsDeleted == false")
                .ToList().ToList()
                    : context.Set<Iş>().Where("IsDeleted == false").Where(filter)
                .ToList();
                return entities;
            }
        }

        public List<Iş> GetAllIncludedPagination(Expression<Func<Iş, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Iş>().Where("IsDeleted == false")
                      .Where(o =>
                    search == null ? o.IşAdı == o.IşAdı :
                    o.IşAdı.ToLower().Contains(search.ToLower())
                    )


               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Iş>().Where("IsDeleted == false").Where(filter)
                   .Where(o =>
                    search == null ? o.IşAdı == o.IşAdı :
                    o.IşAdı.ToLower().Contains(search.ToLower())
                    )

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Iş, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Iş>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Iş>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
