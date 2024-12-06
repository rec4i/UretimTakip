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
    public class KareKodKoliRepository : EntityReposiyoryBase<KareKodKoli, AppIdentityDbContext>, IKareKodKoliRepository
    {
        public List<KareKodKoli> GetAllIncluded(Expression<Func<KareKodKoli, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodKoli>().Where("IsDeleted == false")

                    //KareKodIsEmriIstasyonMTM
                    .ToList().ToList()
                    : context.Set<KareKodKoli>().Where("IsDeleted == false").Where(filter)


                    .ToList();
                return entities;
            }
        }

        public List<KareKodKoli> GetAllIncludedPagination(Expression<Func<KareKodKoli, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodKoli>().Where("IsDeleted == false")


                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KareKodKoli>().Where("IsDeleted == false").Where(filter)

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }
        public int GetAllIncludedPaginationCount(Expression<Func<KareKodKoli, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodKoli>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<KareKodKoli>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

        public KareKodKoli GetLast(Expression<Func<KareKodKoli, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodKoli>().Where("IsDeleted == false").OrderByDescending(o => o.Id).FirstOrDefault()
                    : context.Set<KareKodKoli>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.Id).FirstOrDefault();
                return entities;
            }
        }
        public KareKodKoli GetMax(Expression<Func<KareKodKoli, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodKoli>().Where("IsDeleted == false").OrderByDescending(o => o.SeriNo).FirstOrDefault()
                    : context.Set<KareKodKoli>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.SeriNo).FirstOrDefault();
                return entities;
            }
        }
    }
}
