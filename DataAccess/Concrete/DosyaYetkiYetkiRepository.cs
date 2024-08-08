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
    public class DosyaYetkiYetkiRepository : EntityReposiyoryBase<DosyaYetkiYetki, AppIdentityDbContext>, IDosyaYetkiYetkiRepository
    {
        public List<DosyaYetkiYetki> GetAllIncluded(Expression<Func<DosyaYetkiYetki, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaYetkiYetki>().Where("IsDeleted == false")
                    .Include("User")
                    .Include("Dosya")

                .ToList().ToList()
                    : context.Set<DosyaYetkiYetki>().Where("IsDeleted == false").Where(filter)
                    .Include("User")
                    .Include("Dosya")

                .ToList();
                return entities;
            }
        }

        public List<DosyaYetkiYetki> GetAllIncludedPagination(Expression<Func<DosyaYetkiYetki, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaYetkiYetki>().Where("IsDeleted == false")
                    .Include("User")
               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<DosyaYetkiYetki>().Where("IsDeleted == false").Where(filter)
                .Include("User")
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }

        public int GetAllIncludedPaginationCount(Expression<Func<DosyaYetkiYetki, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<DosyaYetkiYetki>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<DosyaYetkiYetki>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
