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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class KareKodBildirimEmriRepository : EntityReposiyoryBase<KareKodBildirimEmri, AppIdentityDbContext>, IKareKodBildirimEmriRepository
    {
        public List<KareKodBildirimEmri> GetAllIncluded(Expression<Func<KareKodBildirimEmri, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimEmri>().Where("IsDeleted == false")
                    .Include("KareKodAnaUrun")
                    .Include("KareKodBildirimTürü")
                    .Include("KareKodMüşteri")

                    .ToList().ToList()
                    : context.Set<KareKodBildirimEmri>().Where("IsDeleted == false").Where(filter)
                    .Include("KareKodAnaUrun")
                    .Include("KareKodBildirimTürü")

                    .Include("KareKodMüşteri")

                    .ToList();
                return entities;
            }
        }

        public List<KareKodBildirimEmri> GetAllIncludedPagination(Expression<Func<KareKodBildirimEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id)
                      .Include("KareKodAnaUrun")
                    .Include("KareKodBildirimTürü")
                    .Include("KareKodMüşteri")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()


                    : context.Set<KareKodBildirimEmri>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.Id)
                    .Include("KareKodAnaUrun")
                    .Include("KareKodBildirimTürü")
                    .Include("KareKodMüşteri")
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<KareKodBildirimEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id).ToList().Count()
                    : context.Set<KareKodBildirimEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id).Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
