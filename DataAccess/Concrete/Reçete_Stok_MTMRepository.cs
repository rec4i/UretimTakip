using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete;
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
    public class Reçete_Stok_MTMRepository : EntityReposiyoryBase<Reçete_Stok_MTM, AppIdentityDbContext>, IReçete_Stok_MTMRepository
    {
        public List<Reçete_Stok_MTM> GetAllIncluded(Expression<Func<Reçete_Stok_MTM, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false")
                    .Include("Reçete")
                    .Include("Stok")
                    .ToList().ToList()
                    : context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false").Where(filter)
                  .Include("Reçete")
                    .Include("Stok")
                    .ToList();
                return entities;
            }
        }

        public List<Reçete_Stok_MTM> GetAllIncludedPagination(Expression<Func<Reçete_Stok_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false")
                 .Include("Reçete")
                    .Include("Stok")
 .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false").Where(filter)
                     .Include("Reçete")
                    .Include("Stok")

                  .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Reçete_Stok_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Reçete_Stok_MTM>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
