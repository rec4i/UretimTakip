using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers;

namespace DataAccess.Concrete
{
    public class ExportedFileRepository : EntityReposiyoryBase<ExportedFile, AppIdentityDbContext>, IExportedFileRepository
    {
        public  async Task<ExportedFile> AddAsnyc(ExportedFile entity)
        {
            using (var context = new AppIdentityDbContext())
            {
                var _entitiy=  context.Add(entity);
                context.SaveChanges();
                return _entitiy.Entity;
            }
        }
    }
}
