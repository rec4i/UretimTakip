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
    public class Reçete_İş_MTM_DoldurlacakDökümanRepository : EntityReposiyoryBase<Reçete_İş_MTM_DoldurlacakDöküman, AppIdentityDbContext>, IReçete_İş_MTM_DoldurlacakDökümanRepository
    {
    }
}
