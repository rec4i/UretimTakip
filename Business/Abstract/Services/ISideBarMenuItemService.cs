using Business.Concrete.Services;
using Entities.Concrete;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.EntityHelpers;

namespace Business.Abstract.Services
{
    public interface ISideBarMenuItemService
    {
        SideBarMenuItem GetById(int id);
        IEnumerable<TreeItem<SideBarMenuItem>> GetAll(string OpenPath);

        List<SideBarMenuItem> GetByParentId(int? ParentId);
        int Count();
        void Delete(SideBarMenuItem entity);
        void Update(SideBarMenuItem entity);
        void Add(SideBarMenuItem entity);
        List<SideBarMenuItem> GetAllIsParentList();
        List<SideBarMenuItem> GetAllChildList();
        List<SideBarMenuItem> GetAllChildListByParentId(int parentId);
        List<SideBarMenuItem> GetAll();
    }
}
