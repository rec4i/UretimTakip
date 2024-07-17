using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Concrete
{
    public class SideBarMenuItemRepository : EntityReposiyoryBase<SideBarMenuItem, AppIdentityDbContext>, ISideBarMenuItemRepository
    {

    }
}
