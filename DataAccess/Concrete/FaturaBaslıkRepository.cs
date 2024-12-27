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
    public class FaturaBaslıkRepository : EntityReposiyoryBase<FaturaBaslık, AppIdentityDbContext>, IFaturaBaslıkRepository
    {
        public List<FaturaBaslık> GetAllIncluded(Expression<Func<FaturaBaslık, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<FaturaBaslık>().Where("IsDeleted == false")
                    .Include("FaturaDetays.Stok")
                    .Include("FaturaSeri")
                .ToList().ToList()
                    : context.Set<FaturaBaslık>().Where("IsDeleted == false").Where(filter)
                    .Include("FaturaDetays.Stok")
                    .Include("FaturaSeri")

                .ToList();
                return entities;
            }
        }

        public List<FaturaBaslık> GetAllIncludedPagination(Expression<Func<FaturaBaslık, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<FaturaBaslık>().Where("IsDeleted == false").OrderByDescending(o => o.Id)
                    .Include("FaturaDetays.Stok")

               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<FaturaBaslık>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.Id)
                    .Include("FaturaDetays.Stok")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<FaturaBaslık, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<FaturaBaslık>().Where("IsDeleted == false").OrderByDescending(o => o.Id).ToList().Count()
                    : context.Set<FaturaBaslık>().Where("IsDeleted == false").Where(filter).OrderByDescending(o => o.Id).ToList().Count();
                return entities;
            }
        }
    }
}
