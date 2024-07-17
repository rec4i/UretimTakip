using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.AnnouncementDtos;
using Entities.Concrete.VmDtos.AnnouncementRoleDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;

namespace Business.Concrete.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRoleRepository _announcementRoleRepository;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IAnnouncementUserRepository _announcementUserRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private string _currentUserId;


        public AnnouncementService(
            IAnnouncementRepository announcementRepository,
            IAnnouncementRoleRepository announcementRoleRepository,
            UserManager<AppIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            IAnnouncementUserRepository announcementUserRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementRoleRepository = announcementRoleRepository;
            _announcementUserRepository = announcementUserRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _contextAccessor = httpContextAccessor;

            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                _currentUserId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
            else
                _currentUserId = "null";
        }

        public void Add(AddAnnouncementDto entity)
        {


            bool IsSeeAllUser = true;

            if (entity.AnnouncementRolesList != null)
            {
                entity.AnnouncementRoles = new List<AnnouncementRole>();
                foreach (var Role in entity.AnnouncementRolesList)
                {
                    AnnouncementRole announcementRole = new AnnouncementRole();
                    announcementRole.Role = Role;
                    entity.AnnouncementRoles.Add(announcementRole);
                }
                IsSeeAllUser = false;
            }
            if (entity.AnnouncementUsersList != null)
            {
                entity.AnnouncementUsers = new List<AnnouncementUser>();
                foreach (var User in entity.AnnouncementUsersList)
                {
                    AnnouncementUser announcementUser = new AnnouncementUser();
                    announcementUser.UserId = User;
                    entity.AnnouncementUsers.Add(announcementUser);

                }
                IsSeeAllUser = false;
            }
            if (IsSeeAllUser)
                entity.Type = "1";
            else
                entity.Type = null;

            _announcementRepository.Add(ObjectMapper.Mapper.Map<Announcement>(entity));



        }

        public int GellAllCount()
        {
            return _announcementRepository.GetAll().Count();
        }

        public int GellAllCount(FilterQueryStringModel filterQueryStringModel)
        {
            return _announcementRepository.GetWithTableFilterCount(filterQueryStringModel);
        }

        public ListAnnouncementDto Get(int Id)
        {
            var Deneme = _announcementRepository.GetFull(o => o.Id == Id);
            return ObjectMapper.Mapper.Map<ListAnnouncementDto>(_announcementRepository.GetFull(o => o.Id == Id));
        }

        public List<ListAnnouncementDto> GetAll()
        {
            return ObjectMapper.Mapper.Map<List<ListAnnouncementDto>>(_announcementRepository.GetAll());
        }



        public List<ListAnnouncementDto> GetAll(FilterQueryStringModel filterQueryStringModel)
        {
            var Announcuments = _announcementRepository.GetWithPagination(filterQueryStringModel);
            return ObjectMapper.Mapper.Map<List<ListAnnouncementDto>>(Announcuments);
        }

        public List<ListAnnouncementDto> GetUserAnnouncments(string UserId = null)
        {
            AppIdentityUser appIdentityUser = new AppIdentityUser();
            if (UserId != null)
                appIdentityUser = _userManager.Users.Where(o => o.Id == UserId).FirstOrDefault();
            else
                appIdentityUser = _userManager.Users.Where(o => o.Id == _currentUserId).FirstOrDefault();


            //UserRole Göre DuyuruId Çekme
            List<string> UserRoles = _userManager.GetRolesAsync(appIdentityUser).Result.ToList();
            List<int> RoleIds = _announcementRoleRepository.GetAll(o => UserRoles.Any(x => o.Role == x)).Select(o => o.AnnouncementId).ToList();


            //UserId Göre DuyuruId Çekme
            List<int> UserIds = _announcementUserRepository.GetAll(o => o.UserId == appIdentityUser.UserName).Select(o => o.AnnouncementId).ToList();


            //Tüm Duyuru  Idlerin Birleşimi 
            List<int> AllIds = RoleIds.Union(UserIds).Distinct().ToList();


            return ObjectMapper.Mapper.Map<List<ListAnnouncementDto>>(_announcementRepository.GetAll(o => AllIds.Any(x => x == o.Id)));

        }

        public List<ListAnnouncementDto> GetUserAnnouncments(FilterQueryStringModel filterQueryStringModel, string UserId = null)
        {

            AppIdentityUser appIdentityUser = new AppIdentityUser();
            if (UserId != null)
                appIdentityUser = _userManager.Users.Where(o => o.Id == UserId).FirstOrDefault();
            else
                appIdentityUser = _userManager.Users.Where(o => o.Id == _currentUserId).FirstOrDefault();


            //UserRole Göre DuyuruId Çekme
            List<string> UserRoles = _userManager.GetRolesAsync(appIdentityUser).Result.ToList();
            List<int> RoleIds = _announcementRoleRepository.GetAll(o => UserRoles.Any(x => o.Role == x)).Select(o => o.AnnouncementId).ToList();


            //UserId Göre DuyuruId Çekme
            List<int> UserIds = _announcementUserRepository.GetAll(o => o.UserId == appIdentityUser.UserName).Select(o => o.AnnouncementId).ToList();


            //Tüm Duyuru  Idlerin Birleşimi 
            List<int> AllIds = RoleIds.Union(UserIds).Distinct().ToList();



            return ObjectMapper.Mapper.Map<List<ListAnnouncementDto>>(_announcementRepository.GetWithPagination(filterQueryStringModel, AllIds));

        }

        public int GetUserAnnouncmentsCount(string UserId = null)
        {
            AppIdentityUser appIdentityUser = new AppIdentityUser();
            if (UserId != null)
                appIdentityUser = _userManager.Users.Where(o => o.Id == UserId).FirstOrDefault();
            else
                appIdentityUser = _userManager.Users.Where(o => o.Id == _currentUserId).FirstOrDefault();


            //UserRole Göre DuyuruId Çekme
            List<string> UserRoles = _userManager.GetRolesAsync(appIdentityUser).Result.ToList();
            List<int> RoleIds = _announcementRoleRepository.GetAll(o => UserRoles.Any(x => o.Role == x)).Select(o => o.AnnouncementId).ToList();


            //UserId Göre DuyuruId Çekme
            List<int> UserIds = _announcementUserRepository.GetAll(o => o.UserId == appIdentityUser.UserName).Select(o => o.AnnouncementId).ToList();


            //Tüm Duyuru  Idlerin Birleşimi 
            List<int> AllIds = RoleIds.Union(UserIds).Distinct().ToList();


            return _announcementRepository.GetAll(o => AllIds.Any(x => x == o.Id)).Count();
        }

        public int GetUserAnnouncmentsCount(FilterQueryStringModel filterQueryStringModel, string UserId = null)
        {


            AppIdentityUser appIdentityUser = new AppIdentityUser();
            if (UserId != null)
                appIdentityUser = _userManager.Users.Where(o => o.Id == UserId).FirstOrDefault();
            else
                appIdentityUser = _userManager.Users.Where(o => o.Id == _currentUserId).FirstOrDefault();


            //UserRole Göre DuyuruId Çekme
            List<string> UserRoles = _userManager.GetRolesAsync(appIdentityUser).Result.ToList();
            List<int> RoleIds = _announcementRoleRepository.GetAll(o => UserRoles.Any(x => o.Role == x)).Select(o => o.AnnouncementId).ToList();


            //UserId Göre DuyuruId Çekme
            List<int> UserIds = _announcementUserRepository.GetAll(o => o.UserId == appIdentityUser.UserName).Select(o => o.AnnouncementId).ToList();


            //Tüm Duyuru  Idlerin Birleşimi 
            List<int> AllIds = RoleIds.Union(UserIds).Distinct().ToList();


            return _announcementRepository.GetWithPaginationcCount(filterQueryStringModel, AllIds);
        }

        public void Remove(RemoveAnnouncementDto entity)
        {
            _announcementRepository.Delete(ObjectMapper.Mapper.Map<Announcement>(entity));
        }


        public void Update(UpdateAnnouncementDto entity)
        {
            //Eski Verileri Silme
            List<AnnouncementRole> announcementRoles = _announcementRoleRepository.GetAll(o => o.AnnouncementId == entity.Id);
            foreach (var _entity in announcementRoles)
                _announcementRoleRepository.Delete(_entity, true);
            List<AnnouncementUser> announcementUsers = _announcementUserRepository.GetAll(o => o.AnnouncementId == entity.Id);
            foreach (var _entity in announcementUsers)
                _announcementUserRepository.Delete(_entity, true);

            bool IsSeeAllUser = true;

            if (entity.AnnouncementRolesList != null)
            {
                foreach (var Role in entity.AnnouncementRolesList)
                {
                    AnnouncementRole announcementRole = new AnnouncementRole();
                    announcementRole.AnnouncementId = entity.Id;
                    announcementRole.Role = Role;
                    _announcementRoleRepository.Add(announcementRole);
                }
                IsSeeAllUser = false;
            }
            if (entity.AnnouncementUsersList != null)
            {
                foreach (var User in entity.AnnouncementUsersList)
                {
                    AnnouncementUser announcementUser = new AnnouncementUser();
                    announcementUser.AnnouncementId = entity.Id;
                    announcementUser.UserId = User;

                    _announcementUserRepository.Add(announcementUser);
                }
                IsSeeAllUser = false;
            }

            if (IsSeeAllUser)
                entity.Type = "1";
            else
                entity.Type = null;

            //Olan Anonsu Güncelleme
            _announcementRepository.Update(ObjectMapper.Mapper.Map<Announcement>(entity));



        }
    }
}
