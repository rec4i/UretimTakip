using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.BaseEntities;
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
    public class BlokGörüntüRepository : EntityReposiyoryBase<BlokGörüntü, AppIdentityDbContext>, IBlokGörüntüRepository
    {
        public List<BlokGörüntü> GetAllIncluded(Expression<Func<BlokGörüntü, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokGörüntü>().Where("IsDeleted == false")
                //.Include("CarKilometers")
                .ToList().ToList()
                    : context.Set<BlokGörüntü>().Where("IsDeleted == false").Where(filter)
                //.Include("CarKilometers")
                .ToList();
                return entities;
            }
        }

        public List<BlokGörüntü> GetAllIncludedPagination(Expression<Func<BlokGörüntü, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokGörüntü>().Where("IsDeleted == false")
                //.Include("CarKilometers")


                .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(limit)).ToList()
                    : context.Set<BlokGörüntü>().Where("IsDeleted == false").Where(filter)
                    //.Include("CarKilometers")

                    .Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(limit)).ToList();
                return entities;
            }
        }

        public int GetAllIncludedPaginationCount(Expression<Func<BlokGörüntü, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<BlokGörüntü>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<BlokGörüntü>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
