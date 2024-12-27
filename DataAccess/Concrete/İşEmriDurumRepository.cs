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
    public class İşEmriDurumRepository : EntityReposiyoryBase<İşEmriDurum, AppIdentityDbContext>, IİşEmriDurumRepository
    {
        public List<İşEmriDurum> GetAllIncluded(Expression<Func<İşEmriDurum, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {

                var entities = filter == null
                    ? context.Set<İşEmriDurum>().Where("IsDeleted == false")
                    .Include("İşEmri")
                        .Include("Yapılacakİş")

                .ToList().ToList()
                    : context.Set<İşEmriDurum>().Where("IsDeleted == false").Where(filter)
                        .Include("İşEmri")
                        .Include("Yapılacakİş")

                .ToList();
                return entities;
            }
        }

        public List<İşEmriDurum> GetAllIncludedPagination(Expression<Func<İşEmriDurum, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<İşEmriDurum>().Where("IsDeleted == false")
                        .Include("Yapılacakİş")
                        .Include("İşEmri")

               .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<İşEmriDurum>().Where("IsDeleted == false").Where(filter)
                    .Include("Yapılacakİş")
                        .Include("İşEmri")

                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<İşEmriDurum, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<İşEmriDurum>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<İşEmriDurum>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
