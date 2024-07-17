using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Tools.Concrete.HelperClasses.EntityHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers;

namespace Business.Concrete.Services
{
    public class SideBarMenuItemService : ISideBarMenuItemService
    {
        private readonly ISideBarMenuItemRepository _sideBarMenuItemRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public SideBarMenuItemService(
            ISideBarMenuItemRepository sideBarMenuItemRepository,
            IHttpContextAccessor contextAccessor)
        {
            _sideBarMenuItemRepository = sideBarMenuItemRepository;
            _contextAccessor = contextAccessor;
        }
        public void Add(SideBarMenuItem entity)
        {
            _sideBarMenuItemRepository.Add(entity);
        }

        public int Count()
        {
            return _sideBarMenuItemRepository.Count();
        }

        public void Delete(SideBarMenuItem entity)
        {
            _sideBarMenuItemRepository.Delete(entity);
        }

        public IEnumerable<TreeItem<SideBarMenuItem>> GetAll(string OpenPath)
        {
            var sideBarItems = new List<SideBarMenuItem>();
            foreach (var item in _sideBarMenuItemRepository.GetAll(p => p.IsDeleted == false).OrderBy(o => o.Order))
            {
                if (item.Url != "#")
                {
                    var urlArray = item.Url.Split("/");
                    var urlResult = $"Permission.{urlArray[1]}.{urlArray[2]}".ToLower();
                    if (AuthorizedActions().Contains(urlResult) || item.Url.ToLower().Contains("accountinformation") || item.Url.ToLower().Contains("logout"))
                        sideBarItems.Add(item);
                }
                else
                    sideBarItems.Add(item);
            }
            foreach (var item in sideBarItems.ToList())
            {
                if (item.Url == "#")
                {
                    if (!sideBarItems.Any(p => p.ParentId == item.Id))
                        sideBarItems.Remove(item);
                }
            }

            IEnumerable<TreeItem<SideBarMenuItem>> x = sideBarItems.GenerateTree(o => o.Id, o => o.ParentId);
            Test2(ref x, ref x, OpenPath);


            return x;
        }


        private List<string> AuthorizedActions()
        {
            var userPermissions = _contextAccessor.HttpContext.User.Claims.Where(p => p.Value.StartsWith("Permission")).Select(p => p.Value.ToLower()).ToList();
            return userPermissions;
        }

        public void SetParentIdIsOpen(ref IEnumerable<TreeItem<SideBarMenuItem>> categories, ref IEnumerable<TreeItem<SideBarMenuItem>> realData, int deep = 0, int parentId = 0)
        {
            foreach (var c in categories)
            {
                IEnumerable<TreeItem<SideBarMenuItem>> chilcİtem = c.Children;
                if (c.Item.Id == parentId)
                {
                    c.Item.IsOpen = true;
                    c.Item.Name = c.Item.Name;
                    SetParentIdIsOpen(ref realData, ref realData, deep + 1, c.Item.ParentId ?? 0);
                }

                SetParentIdIsOpen(ref chilcİtem, ref realData, deep + 1, parentId);


            }
        }

        public void Test2(ref IEnumerable<TreeItem<SideBarMenuItem>> categories, ref IEnumerable<TreeItem<SideBarMenuItem>> realData, string OpenPath = null)
        {
            foreach (var c in categories)
            {
                IEnumerable<TreeItem<SideBarMenuItem>> chilcİtem = c.Children;
                if (c.Item.Url == OpenPath)
                {
                    c.Item.IsOpen = true;
                    SetParentIdIsOpen(ref realData, ref realData, 0, c.Item.ParentId ?? 0);
                }
                Test2(ref chilcİtem, ref realData, OpenPath);
            }
        }

        public SideBarMenuItem GetById(int id)
        {
            return _sideBarMenuItemRepository.Get(o => o.Id == id);
        }


        public void Update(SideBarMenuItem entity)
        {
            _sideBarMenuItemRepository.Update(entity);
        }

        public List<SideBarMenuItem> GetAllIsParentList()
        {
            return _sideBarMenuItemRepository.GetAll(p => p.IsParent == true).OrderBy(p => p.Row).ToList();
        }

        public List<SideBarMenuItem> GetAllChildList()
        {
            return _sideBarMenuItemRepository.GetAll(p => p.IsParent == false).OrderBy(p => p.Row).ToList();
        }

        public List<SideBarMenuItem> GetAllChildListByParentId(int parentId)
        {
            return _sideBarMenuItemRepository.GetAll(p => p.IsParent == false && p.ParentId == parentId).OrderBy(p => p.Row).ToList();
        }

        public List<SideBarMenuItem> GetByParentId(int? ParentId)
        {
            return _sideBarMenuItemRepository.GetAll(o => o.ParentId == ParentId).ToList();
        }

        public List<SideBarMenuItem> GetAll()
        {
            return _sideBarMenuItemRepository.GetAll(o => o.ParentId == null || o.ParentId == 0).ToList();
        }
    }

}
