using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.BaseEntities;
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
    public class KareKodIsEmriRepository : EntityReposiyoryBase<KareKodIsEmri, AppIdentityDbContext>, IKareKodIsEmriRepository
    {
        public List<KareKodIsEmri> GetAllIncluded(Expression<Func<KareKodIsEmri, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIsEmri>().Where("IsDeleted == false")
                    .Include("BaseProduct")
                    .Include("KareKodIsEmriIstasyonMTM")
                    //KareKodIsEmriIstasyonMTM

                    .ToList().ToList()
                    : context.Set<KareKodIsEmri>().Where("IsDeleted == false").Where(filter)
                    .Include("BaseProduct")
                    .Include("KareKodIsEmriIstasyonMTM")


                    .ToList();
                return entities;
            }
        }

        public List<KareKodIsEmri> GetAllIncludedPagination(Expression<Func<KareKodIsEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIsEmri>().Where("IsDeleted == false").OrderByDescending(o=> o.Id)
                    .Include("BaseProduct")
                    .Include("KareKodIsEmriIstasyonMTM")


                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KareKodIsEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id).Where(filter)
                    .Include("BaseProduct")
                    .Include("KareKodIsEmriIstasyonMTM")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }
        public int GetAllIncludedPaginationCount(Expression<Func<KareKodIsEmri, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodIsEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id).ToList().Count()
                    : context.Set<KareKodIsEmri>().Where("IsDeleted == false").OrderByDescending(o => o.Id).Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
