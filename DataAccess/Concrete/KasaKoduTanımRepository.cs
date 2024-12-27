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
    public class KasaKoduTanımRepository : EntityReposiyoryBase<KasaKoduTanım, AppIdentityDbContext>, IKasaKoduTanımRepository
    {
        public List<KasaKoduTanım> GetAllIncluded(Expression<Func<KasaKoduTanım, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KasaKoduTanım>().Where("IsDeleted == false")
                    .ToList().ToList()
                    : context.Set<KasaKoduTanım>().Where("IsDeleted == false").Where(filter)
                    .ToList();
                return entities;
            }
        }

        public List<KasaKoduTanım> GetAllIncludedPagination(Expression<Func<KasaKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KasaKoduTanım>().Where("IsDeleted == false")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KasaKoduTanım>().Where("IsDeleted == false").Where(filter)


                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<KasaKoduTanım, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KasaKoduTanım>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<KasaKoduTanım>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
