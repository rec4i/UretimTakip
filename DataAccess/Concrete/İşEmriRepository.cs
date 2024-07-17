using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete;
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
    public class İşEmriRepository : EntityReposiyoryBase<İşEmri, AppIdentityDbContext>, IİşEmriRepository
    {
        public List<İşEmri> GetAllIncluded(Expression<Func<İşEmri, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<İşEmri>().Where("IsDeleted == false")
                    .Include("Reçete")
                 .Include("Reçete.Reçete_Iş_MTMs")

                    .Include("Uruns")
                    .Include("Uruns.UrunAşamalarıs")
                    .ToList().ToList()
                    : context.Set<İşEmri>().Where("IsDeleted == false").Where(filter)
                  .Include("Reçete")
                 .Include("Reçete.Reçete_Iş_MTMs")

                    .Include("Uruns")
                    .Include("Uruns.UrunAşamalarıs")
                    .ToList();
                return entities;
            }
        }

        public List<İşEmri> GetAllIncludedPagination(Expression<Func<İşEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<İşEmri>().Where("IsDeleted == false")
                 .Include("Reçete")
                 .Include("Reçete.Reçete_Iş_MTMs")
                    .Include("Uruns")
                    .Include("Uruns.UrunAşamalarıs")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<İşEmri>().Where("IsDeleted == false").Where(filter)
                     .Include("Reçete")
                 .Include("Reçete.Reçete_Iş_MTMs")

                    .Include("Uruns")
                    .Include("Uruns.UrunAşamalarıs")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<İşEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<İşEmri>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<İşEmri>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
