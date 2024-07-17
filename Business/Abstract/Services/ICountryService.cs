using Business.Concrete.Services;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace Business.Abstract.Services
{
    public interface ICountryService
    {
        Country GetById(int id);
        List<Country> GetAll();

        List<Country> TableWithJson(FilterQueryStringModel filterQueryStringModel);

        Country GetByShortName(string shortName);
        int GetCount();
        int GetWithTableFilterCount(FilterQueryStringModel filterQueryStringModel);
        void Delete(Country entity);
        void Update(Country entity);
        void Add(Country entity);
    }
}
