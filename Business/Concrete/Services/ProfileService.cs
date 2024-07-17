using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Profile Add(Profile entity)
        {
            return _profileRepository.Add(entity);
        }

        public void Delete(int Id)
        {
            var result = _profileRepository.Get(o => o.Id == Id);
            _profileRepository.Delete(result);
        }

        public List<Profile> GetAll(Expression<Func<Profile, bool>> filter = null)
        {
            return _profileRepository.GetAll(filter);
        }

        public Profile GetUserProfile(string UserId)
        {
            var resul = _profileRepository.Get(o => o.UserId == UserId);
            return resul;
        }

        public void Update(Profile entity)
        {
            _profileRepository.Update(entity);
        }
    }
}
