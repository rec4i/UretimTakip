using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrete.Contants;
using Business.Contants;
using Entities.Concrete;
using Entities.Concrete.Contants;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.SettingDto;
using Entities.Concrete.VmDtos.SystemAdminDtos;
using Entities.Concrete.VmDtos.SystemUserLogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using WebIU.Models.Setting;

namespace WebIU.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        private readonly ISideBarMenuItemService _sideBarMenuItemService;
        private readonly ICountryService _countryService;
        private readonly ISystemUserLogService _systemUserLogService;
        public SettingController(
            ISideBarMenuItemService sideBarMenuItemService,
            ICountryService countryService,
            ISystemUserLogService systemUserLogService)
        {
            _sideBarMenuItemService = sideBarMenuItemService;
            _countryService = countryService;
            _systemUserLogService = systemUserLogService;
        }
        [HttpGet]
        [Authorize(Permission.Setting.SystemUserLogListSearch)]
        public IActionResult SystemUserLogListSearch()
        {
            var model = new SystemUserLogListSearchViewModel
            {
                SystemUserLogs = new List<SystemUserLogListDto>()
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Setting.SystemUserLogListSearch)]
        public IActionResult SystemUserLogListSearch(SystemUserLogListSearchViewModel model)
        {
            model.SystemUserLogs = _systemUserLogService.SearchedSystemUserLogList(model.Search);
            return View(model);
        }

        [Authorize(Permission.Setting.MenuList)]
        public IActionResult MenuList()
        {
            var isParents = _sideBarMenuItemService.GetAll();
            var model = new MenuListViewModel
            {
                IsParents = ObjectMapper.Mapper.Map<List<SideBarMenuItemDto>>(isParents),
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Permission.Setting.MenuList)]
        public IActionResult MenuListChildItem(int ParentId = 0)
        {
            var isParents = _sideBarMenuItemService.GetByParentId(ParentId);
            var childs = _sideBarMenuItemService.GetAllChildList();
            var model = new MenuListChildItemViewModel
            {
                ParentId = ParentId,
                IsParents = ObjectMapper.Mapper.Map<List<SideBarMenuItemDto>>(isParents),
            };


            return PartialView("MenuListChildItemPartial", model);
        }

        [Authorize(Permission.Setting.MenuList)]
        [HttpGet]
        public IActionResult AddNewMenuItem(int ParentId)
        {
            if (!ModelState.IsValid)
                return View();

            var model = new AddNewMenuItemViewModel
            {
                ParentId = ParentId,
                OrderCount = _sideBarMenuItemService.GetByParentId(ParentId == 0 ? null : ParentId).Count()
            };
            return View(model);
        }

        [Authorize(Permission.Setting.MenuList)]
        [HttpPost]
        public IActionResult AddNewMenuItem(AddNewMenuItemViewModel model)
        {

            var menuItem = new SideBarMenuItem
            {
                ParentId = model.ParentId,
                Name = model.Name,
                IconCss = model.IconCss,
                Url = model.Url,
                Order = model.Order
            };
            //Add New Menu İtem to parent
            if (model.Url == "#")
                menuItem.IsParent = true;
            else
                menuItem.IsParent = false;

            _sideBarMenuItemService.Add(menuItem);

            //Set Parent ,Item to parent
            if (model.ParentId == 0)
            {
                return RedirectToAction("MenuList");
            }

            var ParentMenuItemInstance = _sideBarMenuItemService.GetById(model.ParentId);
            var parentMenuItem = new SideBarMenuItem
            {
                Id = model.ParentId,
                Url = "#",
                IconCss = ParentMenuItemInstance.IconCss,
                IsParent = true,
                Name = ParentMenuItemInstance.Name
            };

            _sideBarMenuItemService.Update(parentMenuItem);
            _systemUserLogService.Add(LogMessage.MenuItemAdded);
            return RedirectToAction("MenuList");
        }

        [HttpGet]
        public IActionResult DeleteMenuItem(int MenuItemId)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("MenuList");
            }
            SideBarMenuItem sideBarMenuItem = new SideBarMenuItem();
            sideBarMenuItem.Id = MenuItemId;
            _sideBarMenuItemService.Delete(sideBarMenuItem);
            _systemUserLogService.Add($"{MenuItemId} {LogMessage.MenuItemDeleted}");
            return RedirectToAction("MenuList");
        }
        [HttpGet]
        [Authorize(Permission.Setting.EditMenuItem)]
        public IActionResult EditMenuItem(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("MenuList");
            }
            var SideBarMenuItemInstance = _sideBarMenuItemService.GetById(id);


            var menuEditViewModel = new MenuEditViewModel
            {
                IconCss = SideBarMenuItemInstance.IconCss,
                Name = SideBarMenuItemInstance.Name,
                Url = SideBarMenuItemInstance.Url,
                Id = SideBarMenuItemInstance.Id,
                ParentId = SideBarMenuItemInstance.ParentId,
                Order = SideBarMenuItemInstance.Order,
                OrderCount = _sideBarMenuItemService.GetByParentId(SideBarMenuItemInstance.ParentId).Count()
            };

            return View(menuEditViewModel);
        }

        [HttpPost]
        [Authorize(Permission.Setting.EditMenuItem)]
        public IActionResult EditMenuItem(MenuEditViewModel model)
        {
            var menuItem = _sideBarMenuItemService.GetById(model.Id);
            menuItem.Url = model.Url;
            menuItem.IconCss = model.IconCss;
            menuItem.Name = model.Name;
            menuItem.Order = model.Order;
            _sideBarMenuItemService.Update(menuItem);
            _systemUserLogService.Add($"{model.Id} ({model.Name}) {LogMessage.MenuItemEdit}");
            return RedirectToAction("MenuList");
        }
        [Authorize(Permission.Setting.MenuItemDelete)]
        public IActionResult MenuItemDelete(int id)
        {
            var menuItem = _sideBarMenuItemService.GetById(id);
            if (menuItem != null)
            {
                _sideBarMenuItemService.Delete(menuItem);
                _systemUserLogService.Add($"{id} ({menuItem.Name}) {LogMessage.MenuItemDeleted}");
                return Json("");
            }
            return Json(null);
        }
        [Authorize(Permission.Setting.AnnouncementList)]
        public IActionResult AnnouncementList()
        {
            return View();
        }
        [Authorize(Permission.Setting.CountryList)]
        public IActionResult CountryList()
        {
            var countries = ObjectMapper.Mapper.Map<List<CountryDto>>(_countryService.GetAll());
            var model = new CountryListViewModel
            {
                Countries = countries
            };
            return View(model);
        }
        public IActionResult TableWithJson_CountryList(FilterQueryStringModel filterQueryStringModel)
        {

            var countries = ObjectMapper.Mapper.Map<List<CountryDto>>(_countryService.TableWithJson(filterQueryStringModel));
            CountryListTableViewModel _model = new CountryListTableViewModel();

            _model.rows = countries;
            _model.totalNotFiltered = _countryService.GetWithTableFilterCount(filterQueryStringModel);
            _model.total = countries.Count();

            return new OkObjectResult(_model);

        }
        [HttpGet]
        [Authorize(Permission.Setting.CountryAddAndEdit)]
        public IActionResult CountryAddAndEdit(int Id = 0)
        {
            if (Id > 0)
            {
                var countryDto = ObjectMapper.Mapper.Map<CountryDto>(_countryService.GetById(Id));
                var model = new CountryAddAndEditViewModel
                {
                    Country = countryDto,
                };
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [Authorize(Permission.Setting.CountryAddAndEdit)]
        public IActionResult CountryAddAndEdit(CountryAddAndEditViewModel countryAddAndEditViewModel)
        {
            if (countryAddAndEditViewModel.Country.Id > 0)
                EditCountry(countryAddAndEditViewModel);
            else
                AddCountry(countryAddAndEditViewModel);

            TempData.Add("swalMessage", Messages.Successful);

            return RedirectToAction("CountryList", "Setting");
        }
        private void EditCountry(CountryAddAndEditViewModel model)
        {
            var defautRow = _countryService.GetById(model.Country.Id).Row;

            if (defautRow < model.Country.Row)
                model.Country.Row += 1;
            var country = ObjectMapper.Mapper.Map<Country>(model.Country);
            _countryService.Update(country);
            _systemUserLogService.Add($"{model.Country.Id} ({model.Country.Name}) {LogMessage.CountryEdit}");
            ReorderCountry(_countryService.GetAll());
        }
        private void AddCountry(CountryAddAndEditViewModel model)
        {
            var country = ObjectMapper.Mapper.Map<Country>(model.Country);
            if (country.Row == 0)
                country.Row = _countryService.GetCount();

            _countryService.Add(country);
            _systemUserLogService.Add($"{model.Country.Id} ({model.Country.Name}) {LogMessage.CountryAdded}");
            ReorderCountry(_countryService.GetAll());
        }
        [Authorize(Permission.Setting.CountryDelete)]
        public IActionResult CountryDelete(int Id)
        {
            var country = _countryService.GetById(Id);
            if (country != null)
            {
                _countryService.Delete(country);
                _systemUserLogService.Add($"{Id} ({country.Name}) {LogMessage.CountryDeleted}");
                ReorderCountry(_countryService.GetAll());
                return Json("");
            }
            return Json(null);
        }
        private void ReorderCountry(List<Country> countries)
        {
            int row = 1;
            foreach (var item in countries)
            {
                item.Row = row;
                _countryService.Update(item);
                row++;
            }

        }
    }
}
