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
    public class UrunRepository : EntityReposiyoryBase<Urun, AppIdentityDbContext>, IUrunRepository
    {
        public List<Urun> GetAllIncluded(Expression<Func<Urun, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Urun>().Where("IsDeleted == false")
                    .Include("UrunAşamalarıs")
                    .Include("UrunAşamalarıs.Iş")
                    .Include("İşEmri")
                    .ToList().ToList()
                    : context.Set<Urun>().Where("IsDeleted == false").Where(filter)
                   .Include("UrunAşamalarıs")
                    .Include("UrunAşamalarıs.Iş")

                    .Include("İşEmri")

                    .ToList();
                return entities;
            }
        }

        public List<Urun> GetAllIncludedPagination(Expression<Func<Urun, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Urun>().Where("IsDeleted == false")

                    //.Include("UrunAşamalarıs")
                    //.Include("İşEmri")
                    //.Include("UrunAşamalarıs.Iş")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Urun>().Where("IsDeleted == false").Where(filter)
                    //.Include("UrunAşamalarıs")
                    //.Include("İşEmri")
                    //.Include("UrunAşamalarıs.Iş")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Urun, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Urun>().Where("IsDeleted == false").Count()
                    : context.Set<Urun>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
