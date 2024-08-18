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
    public class KareKodUrunlerRepository : EntityReposiyoryBase<KareKodUrunler, AppIdentityDbContext>, IKareKodUrunlerRepository
    {
        public List<KareKodUrunler> GetAllIncluded(Expression<Func<KareKodUrunler, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodUrunler>().Where("IsDeleted == false")

                    .ToList().ToList()
                    : context.Set<KareKodUrunler>().Where("IsDeleted == false").Where(filter)

                    .ToList();
                return entities;
            }
        }

        public List<KareKodUrunler> GetAllIncludedPagination(Expression<Func<KareKodUrunler, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodUrunler>().Where("IsDeleted == false")


                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KareKodUrunler>().Where("IsDeleted == false").Where(filter)


                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }

        public int GetAllIncludedPaginationCount(Expression<Func<KareKodUrunler, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodUrunler>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<KareKodUrunler>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

        public KareKodUrunler GetLast(Expression<Func<KareKodUrunler, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodUrunler>().Where("IsDeleted == false").OrderByDescending(o => o.Id).FirstOrDefault()

                    : context.Set<KareKodUrunler>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.Id).FirstOrDefault();


                return entities;
            }
        }
    }
}
