using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrete.Contants;
using Business.Contants;
using Entities.Concrete.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.RoleDtos;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebIU.Models.Role;

namespace WebIU.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISystemUserLogService _systemUserLogService;
        public RoleController(
            UserManager<AppIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ISystemUserLogService systemUserLogService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _systemUserLogService = systemUserLogService;
        }
        [Authorize(Permission.Role.RoleList)]
        public IActionResult RoleList()
        {
            var model = new AllRolesViewModel
            {
                Roles = _roleManager.Roles
            };
            _systemUserLogService.Add(LogMessage.RoleList);
            return View(model);
        }

        [HttpGet]
        [Authorize(Permission.Role.CreateRole)]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Permission.Role.CreateRole)]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(createRoleViewModel);
            }
            var role = new IdentityRole
            {
                Name = createRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleCreate}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("RoleList", "Role");
            }
            AddModalStateErrors(result);
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleNotCreate}",LogTrxResult.Fail);
            return View(createRoleViewModel);
        }
        [Authorize(Permission.Role.RoleDelete)]
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleList", "Role");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleDelete}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("RoleList", "Role");
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleNotDelete}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return RedirectToAction("RoleList", "Role");
        }
        [HttpGet]
        [Authorize(Permission.Role.RoleEdit)]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleEdit", "Role", new { id = id });
            }
            var roleUsers = await _userManager.GetUsersInRoleAsync(role.Name);
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var roleUsersDto = ObjectMapper.Mapper.Map<List<ShortUserInfoDto>>(roleUsers);
            var model = new RoleEditViewModel
            {
                Id = id,
                Permissions = roleClaims,
                RoleName = role.Name,
                Users = roleUsersDto
            };

            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Role.RoleEdit)]
        public async Task<IActionResult> RoleEdit(RoleEditViewModel roleEditViewModel)
        {
            var role = await _roleManager.FindByIdAsync(roleEditViewModel.Id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleEdit", "Role", new { id = roleEditViewModel.Id });
            }

            role.Name = roleEditViewModel.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleEdit}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("RoleList", "Role");
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleNotEdit}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(roleEditViewModel);
        }
        [HttpGet]
        [Authorize(Permission.Role.EditUserInRole)]
        public async Task<IActionResult> EditUserInRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleEdit", "Role", new { id = Id });
            }
            var userList = new List<EditRoleUsersDto>();
            foreach (var user in _userManager.Users)
            {
                var editRoleUserDto = ObjectMapper.Mapper.Map<EditRoleUsersDto>(user);

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    editRoleUserDto.IsSelected = true;
                else
                    editRoleUserDto.IsSelected = false;

                userList.Add(editRoleUserDto);
            }

            var model = new EditUserInRoleViewModel
            {
                RoleId = role.Id,
                Users = userList
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Role.EditUserInRole)]
        public async Task<IActionResult> EditUserInRole(EditUserInRoleViewModel editUserInRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editUserInRoleViewModel.RoleId);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("EditUserInRole", "Role", new { id = editUserInRoleViewModel.RoleId });
            }
            IdentityResult result = new IdentityResult();
            for (int i = 0; i < editUserInRoleViewModel.Users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(editUserInRoleViewModel.Users[i].Id);
                if (editUserInRoleViewModel.Users[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                else if (!editUserInRoleViewModel.Users[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                else
                    continue;
            }
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleEdit}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("RoleEdit", "Role", new { id = editUserInRoleViewModel.RoleId });
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditUserInRoleNot}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(editUserInRoleViewModel);
        }
        [HttpGet]
        [Authorize(Permission.Role.EditPermissionInRole)]
        public async Task<IActionResult> EditPermissionInRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleEdit", new { id = Id });
            }
            var permissions = Permission.GetPermissions();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var editPermissionInRolesDto = new List<EditPermissionInRoleDto>();

            foreach (var permission in permissions)
            {
                var editPermissionInRoleDto = new EditPermissionInRoleDto();
                editPermissionInRoleDto.Permission = permission;

                if (roleClaims.Any(p => p.Value == permission))
                    editPermissionInRoleDto.IsSelected = true;

                editPermissionInRolesDto.Add(editPermissionInRoleDto);
            }

            var model = new EditPermissionInRoleViewModel
            {
                Permissions = editPermissionInRolesDto,
                RoleId = Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Role.EditPermissionInRole)]
        public async Task<IActionResult> EditPermissionInRole(EditPermissionInRoleViewModel editPermissionInRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editPermissionInRoleViewModel.RoleId);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("RoleEdit", new { editPermissionInRoleViewModel.RoleId });
            }
            IdentityResult result = new IdentityResult();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            for (int i = 0; i < editPermissionInRoleViewModel.Permissions.Count; i++)
            {
                var permissionName = editPermissionInRoleViewModel.Permissions[i].Permission;
                if (editPermissionInRoleViewModel.Permissions[i].IsSelected && !roleClaims.Any(p => p.Value == permissionName))
                    result = await _roleManager.AddClaimAsync(role, new Claim("Permission", permissionName));
                else if (!editPermissionInRoleViewModel.Permissions[i].IsSelected && roleClaims.Any(p => p.Value == permissionName))
                    result = await _roleManager.RemoveClaimAsync(role, new Claim("Permission", permissionName));
            }
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditPermissionInRole}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("RoleEdit", "Role", new { id = editPermissionInRoleViewModel.RoleId });
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditPermissionInRoleNot}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(editPermissionInRoleViewModel);
        }
        private void AddModalStateErrors(IdentityResult result)
        {
            if (result.Errors.ToList().Count > 0 && TempData["message"] == null)
                TempData["message"] = " ";

            result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
        }
     
       
     
        
        [HttpGet]
        [Authorize(Permission.Role.ImplementerRoleEdit)]
        public async Task<IActionResult> ImplementerRoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("ImplementerRoleEdit", "Role", new { id = id });
            }
            var roleUsers = await _userManager.GetUsersInRoleAsync(role.Name);
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var roleUsersDto = ObjectMapper.Mapper.Map<List<ShortUserInfoDto>>(roleUsers);
            var model = new RoleEditViewModel
            {
                Id = id,
                Permissions = roleClaims,
                RoleName = role.Name,
                Users = roleUsersDto
            };

            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Role.ImplementerRoleEdit)]
        public async Task<IActionResult> ImplementerRoleEdit(RoleEditViewModel roleEditViewModel)
        {
            var role = await _roleManager.FindByIdAsync(roleEditViewModel.Id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("ImplementerRoleEdit", "Role", new { id = roleEditViewModel.Id });
            }

            role.Name = roleEditViewModel.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleEdit}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("ImplementerRoleList", "Role");
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleNotEdit}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(roleEditViewModel);
        }
        [HttpGet]
        [Authorize(Permission.Role.ImplementerEditPermissionInRole)]
        public async Task<IActionResult> ImplementerEditPermissionInRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("ImplementerRoleEdit", new { id = Id });
            }
            var permissions = PermissionImplementer.GetPermissions();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var editPermissionInRolesDto = new List<EditPermissionInRoleDto>();

            foreach (var permission in permissions)
            {
                var editPermissionInRoleDto = new EditPermissionInRoleDto();
                editPermissionInRoleDto.Permission = permission;

                if (roleClaims.Any(p => p.Value == permission))
                    editPermissionInRoleDto.IsSelected = true;

                editPermissionInRolesDto.Add(editPermissionInRoleDto);
            }

            var model = new EditPermissionInRoleViewModel
            {
                Permissions = editPermissionInRolesDto,
                RoleId = Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.Role.ImplementerEditPermissionInRole)]
        public async Task<IActionResult> ImplementerEditPermissionInRole(EditPermissionInRoleViewModel editPermissionInRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editPermissionInRoleViewModel.RoleId);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("ImplementerRoleEdit", new { editPermissionInRoleViewModel.RoleId });
            }
            IdentityResult result = new IdentityResult();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            for (int i = 0; i < editPermissionInRoleViewModel.Permissions.Count; i++)
            {
                var permissionName = editPermissionInRoleViewModel.Permissions[i].Permission;
                if (editPermissionInRoleViewModel.Permissions[i].IsSelected && !roleClaims.Any(p => p.Value == permissionName))
                    result = await _roleManager.AddClaimAsync(role, new Claim("Permission", permissionName));
                else if (!editPermissionInRoleViewModel.Permissions[i].IsSelected && roleClaims.Any(p => p.Value == permissionName))
                    result = await _roleManager.RemoveClaimAsync(role, new Claim("Permission", permissionName));
            }
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditPermissionInRole}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("ImplementerRoleEdit", "Role", new { id = editPermissionInRoleViewModel.RoleId });
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditPermissionInRoleNot}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(editPermissionInRoleViewModel);
        }

      
        [HttpPost]
        [Authorize(Permission.Role.ImplementerEditUserInRole)]
        public async Task<IActionResult> ImplementerEditUserInRole(EditUserInRoleViewModel editUserInRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editUserInRoleViewModel.RoleId);
            if (role == null)
            {
                TempData.Add("message", Messages.NotFoundRole);
                return RedirectToAction("ImplementerEditUserInRole", "Role", new { id = editUserInRoleViewModel.RoleId });
            }
            IdentityResult result = new IdentityResult();
            for (int i = 0; i < editUserInRoleViewModel.Users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(editUserInRoleViewModel.Users[i].Id);
                if (editUserInRoleViewModel.Users[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                else if (!editUserInRoleViewModel.Users[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                else
                    continue;
            }
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.RoleEdit}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("ImplementerRoleEdit", "Role", new { id = editUserInRoleViewModel.RoleId });
            }
            _systemUserLogService.Add($"{role.Id} ({role.Name}) {LogMessage.EditUserInRoleNot}", LogTrxResult.Fail);
            AddModalStateErrors(result);
            return View(editUserInRoleViewModel);
        }







    }
}
