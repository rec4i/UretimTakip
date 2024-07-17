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
    public class Tezgah_Iş_MTMRepository : EntityReposiyoryBase<Tezgah_Iş_MTM, AppIdentityDbContext>, ITezgah_Iş_MTMReposiyory
    {

        public List<Tezgah_Iş_MTM> GetAllIncluded(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false")
                         .Include("Iş")
                    .Include("Tezgah")
                    .ToList().ToList()
                    : context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false").Where(filter)
                         .Include("Iş")
                    .Include("Tezgah")
                    .ToList();
                return entities;
            }
        }

        public List<Tezgah_Iş_MTM> GetAllIncludedPagination(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false")
                    .Include("Iş")
                    .Include("Tezgah")

                  .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false").Where(filter)

                       .Include("Iş")
                    .Include("Tezgah")
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Tezgah_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Tezgah_Iş_MTM>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

    }
}
