using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class DosyaSilmeYetkiRepository : EntityReposiyoryBase<DosyaSilmeYetki, AppIdentityDbContext>, IDosyaSilmeYetkiRepository
    {
        public List<DosyaSilmeYetki> GetAllIncluded(Expression<Func<DosyaSilmeYetki, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaSilmeYetki>().Where("IsDeleted == false")
                    .Include("User")
                    .Include("Dosya")

                .ToList().ToList()
                    : context.Set<DosyaSilmeYetki>().Where("IsDeleted == false").Where(filter)
                    .Include("User")
                    .Include("Dosya")

                .ToList();
                return entities;
            }
        }
        public List<DosyaSilmeYetki> GetAllIncludedPagination(Expression<Func<DosyaSilmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaSilmeYetki>().Where("IsDeleted == false")
                    .Include("User")
                    .Include("Dosya")



               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<DosyaSilmeYetki>().Where("IsDeleted == false").Where(filter)
                    .Include("User")
                    .Include("Dosya")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }

        public int GetAllIncludedPaginationCount(Expression<Func<DosyaSilmeYetki, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaSilmeYetki>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<DosyaSilmeYetki>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
