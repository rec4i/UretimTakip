using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace Business.Concrete.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository CountryRepository)
        {
            _countryRepository = CountryRepository;
        }
        public void Add(Country entity)
        {
            _countryRepository.Add(entity);
        }
        public void Delete(Country entity)
        {
            _countryRepository.Delete(entity);
        }
        public List<Country> GetAll()
        {
            return _countryRepository.GetAll(p=>p.IsDeleted==false).OrderBy(p => p.Row).ToList();
        }
        public Country GetById(int id)
        {
            return _countryRepository.Get(p => p.Id == id);
        }

        public Country GetByShortName(string shortName)
        {
            return _countryRepository.Get(p => p.ShortName == shortName);
        }

        public int GetCount()
        {
            return _countryRepository.GetAll(p => p.IsDeleted == false).Count();
        }

        public int GetWithTableFilterCount(FilterQueryStringModel filterQueryStringModel)
        {
            return _countryRepository.GetWithTableFilterCount(filterQueryStringModel);
        }

        public List<Country> TableWithJson(FilterQueryStringModel filterQueryStringModel)
        {
            return _countryRepository.GetWithTableFilter(filterQueryStringModel);
        }

        public void Update(Country entity)
        {
            _countryRepository.Update(entity);
        }
    }

}
