using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;

namespace DataAccess.Concrete
{
    public class BelgeSoruSeçenekRepository : EntityReposiyoryBase<BelgeSoruSeçenek, AppIdentityDbContext>, IBelgeSoruSeçenekRepository
    {
    }
}
