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
    public class TezgahRepository : EntityReposiyoryBase<Tezgah, AppIdentityDbContext>, ITezgahRepository
    {
        public List<Tezgah> GetAllIncluded(Expression<Func<Tezgah, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah>().Where("IsDeleted == false")
                   .Include("Tezgah_Iş_MTMs")
                    .Include("Tezgah_Iş_MTMs.Iş")
                    .ToList().ToList()
                    : context.Set<Tezgah>().Where("IsDeleted == false").Where(filter)
                    .Include("Tezgah_Iş_MTMs")
                    .Include("Tezgah_Iş_MTMs.Iş")
                    .ToList();
                return entities;
            }
        }

        public List<Tezgah> GetAllIncludedPagination(Expression<Func<Tezgah, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah>().Where("IsDeleted == false")
                    .Include("Reçete_Tezgah_MTMs.Reçete")
                    .Include("Tezgah_Iş_MTMs")
                    .Include("Tezgah_Iş_MTMs.Iş")
                    .Where(o =>
                    search == null ? o.TezgahAdı == o.TezgahAdı :
                    o.TezgahAdı.ToLower().Contains(search.ToLower())
                    )
                  .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Tezgah>().Where("IsDeleted == false").Where(filter)
                    .Include("Reçete_Tezgah_MTMs.Reçete")
                  .Include("Tezgah_Iş_MTMs")
                    .Include("Tezgah_Iş_MTMs.Iş")
                    .Where(o =>
                    search == null ? o.TezgahAdı == o.TezgahAdı :
                    o.TezgahAdı.ToLower().Contains(search.ToLower())
                    )
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Tezgah, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Tezgah>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
