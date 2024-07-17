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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ReçeteRepository : EntityReposiyoryBase<Reçete, AppIdentityDbContext>, IReçeteRepository
    {
        public List<Reçete> GetAllIncluded(Expression<Func<Reçete, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete>().Where("IsDeleted == false")
                //.Include("CarKilometers")
                .ToList().ToList()
                    : context.Set<Reçete>().Where("IsDeleted == false").Where(filter)
                //.Include("CarKilometers")
                .ToList();
                return entities;
            }
        }

        public List<Reçete> GetAllIncludedPagination(Expression<Func<Reçete, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete>().Where("IsDeleted == false")
                      //.Include("CarKilometers")
                      .Where(o =>
                    search == null ? o.ReçeteAdı == o.ReçeteAdı :
                    o.ReçeteAdı.ToLower().Contains(search.ToLower())
                    )


           .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Reçete>().Where("IsDeleted == false").Where(filter)
                   //.Include("CarKilometers")
                   .Where(o =>
                    search == null ? o.ReçeteAdı == o.ReçeteAdı :
                    o.ReçeteAdı.ToLower().Contains(search.ToLower())
                    )
 .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Reçete, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Reçete>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
