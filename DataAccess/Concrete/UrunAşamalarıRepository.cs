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
    public class UrunAşamalarıRepository : EntityReposiyoryBase<UrunAşamaları, AppIdentityDbContext>, IUrunAşamalarıRepository
    {
        public List<UrunAşamaları> GetAllIncluded(Expression<Func<UrunAşamaları, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<UrunAşamaları>().Where("IsDeleted == false")
                    .Include("Iş")
                    .Include("İşiÜstlenenKullanıcı")

                    .ToList().ToList()
                    : context.Set<UrunAşamaları>().Where("IsDeleted == false").Where(filter)
                    .Include("Iş")
                    .Include("İşiÜstlenenKullanıcı")

                    .ToList();
                return entities;
            }
        }
        public List<UrunAşamaları> GetAllIncludedPagination(Expression<Func<UrunAşamaları, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<UrunAşamaları>().Where("IsDeleted == false")
                     .Include("Iş")
                    .Include("İşiÜstlenenKullanıcı")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<UrunAşamaları>().Where("IsDeleted == false").Where(filter)
                     .Include("Iş")
                    .Include("İşiÜstlenenKullanıcı")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }

        public int GetAllIncludedPaginationCount(Expression<Func<UrunAşamaları, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<UrunAşamaları>().Where("IsDeleted == false").Count()
                    : context.Set<UrunAşamaları>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
