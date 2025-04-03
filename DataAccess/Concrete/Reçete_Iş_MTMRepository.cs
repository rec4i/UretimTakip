using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete;
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
    public class Reçete_Iş_MTMRepository : EntityReposiyoryBase<Reçete_Iş_MTM, AppIdentityDbContext>, IReçete_Iş_MTMRepository
    {
        public List<Reçete_Iş_MTM> GetAllIncluded(Expression<Func<Reçete_Iş_MTM, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false")
                    .Include("Reçete")
                    .Include("Iş")
                    .Include("SorumluKullanıcıGrup")
                    .ToList().ToList()
                    : context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false").Where(filter)
                  .Include("Reçete")
                    .Include("Iş")
                    .Include("SorumluKullanıcıGrup")

                    .ToList();
                return entities;
            }
        }

        public List<Reçete_Iş_MTM> GetAllIncludedPagination(Expression<Func<Reçete_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false")
                 .Include("Reçete")
                    .Include("Iş")
                    .Include("SorumluKullanıcıGrup")
                    .Include("Tezgah")

                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false").Where(filter)
                     .Include("Reçete")
                    .Include("Iş")
                    .Include("SorumluKullanıcıGrup")
                    .Include("Tezgah")

                  .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Reçete_Iş_MTM, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Reçete_Iş_MTM>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
