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
    public class KareKodBildirimStokMTMRepository : EntityReposiyoryBase<KareKodBildirimStokMTM, AppIdentityDbContext>, IKareKodBildirimStokMTMRepository
    {
        public List<KareKodBildirimStokMTM> GetAllIncluded(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false")
                    //KareKodIsEmriIstasyonMTM
                    .Include("KareKodBildirimEmri")
                    .Include("KareKodStok")
                    .ToList().ToList()
                    : context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false").Where(filter)
                    .Include("KareKodBildirimEmri")
                    .Include("KareKodStok")


                    .ToList();
                return entities;
            }
        }

        public List<KareKodBildirimStokMTM> GetAllIncludedPagination(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false")
                             .Include("KareKodBildirimEmri")
                    .Include("KareKodStok")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false").Where(filter)
                             .Include("KareKodBildirimEmri")
                    .Include("KareKodStok")
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }
        public int GetAllIncludedPaginationCount(Expression<Func<KareKodBildirimStokMTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<KareKodBildirimStokMTM>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
