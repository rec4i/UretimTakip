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
    public class KareKodIstasyonRepository : EntityReposiyoryBase<KareKodIstasyon, AppIdentityDbContext>, IKareKodIstasyonRepository
    {
        public List<KareKodIstasyon> GetAllIncluded(Expression<Func<KareKodIstasyon, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIstasyon>().Where("IsDeleted == false")

                    //KareKodIsEmriIstasyonMTM
                    .ToList().ToList()
                    : context.Set<KareKodIstasyon>().Where("IsDeleted == false").Where(filter)


                    .ToList();
                return entities;
            }
        }

        public List<KareKodIstasyon> GetAllIncludedPagination(Expression<Func<KareKodIstasyon, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIstasyon>().Where("IsDeleted == false")


                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KareKodIstasyon>().Where("IsDeleted == false").Where(filter)

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }
        public int GetAllIncludedPaginationCount(Expression<Func<KareKodIstasyon, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIstasyon>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<KareKodIstasyon>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
