using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BlokBilgiRepository : EntityReposiyoryBase<BlokBilgi, AppIdentityDbContext>, IBlokBilgiRepository
    {
        public List<BlokBilgi> GetAllIncluded(Expression<Func<BlokBilgi, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokBilgi>().Where("IsDeleted == false")
                //.Include("CarKilometers")
                .ToList().ToList()
                    : context.Set<BlokBilgi>().Where("IsDeleted == false").Where(filter)
                //.Include("CarKilometers")
                .ToList();
                return entities;
            }
        }

        public List<BlokBilgi> GetAllIncludedPagination(Expression<Func<BlokBilgi, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokBilgi>().Where("IsDeleted == false")
                //.Include("CarKilometers")


                .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(limit)).ToList()
                    : context.Set<BlokBilgi>().Where("IsDeleted == false").Where(filter)
                    //.Include("CarKilometers")

                    .Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<BlokBilgi, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokBilgi>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<BlokBilgi>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }

    }
}
