using Business.Abstract.Services;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class CultureService : ICultureService
    {
        private readonly RequestLocalizationOptions _localizationOptions;
        private readonly IHttpContextAccessor _contextAccessor;
        public CultureService(
            IOptions<RequestLocalizationOptions> localizationOptions, IHttpContextAccessor contextAccessor)
        {
            _localizationOptions = localizationOptions.Value;
            _contextAccessor = contextAccessor;
        }
        public List<Culture> GetAll()
        {
            return CultureList();
        }

        public Culture GetCulture(string name)
        {
            return CultureList().Where(p => p.Name == name).ToList().FirstOrDefault();
        }

        public string GetCultureName(string name)
        {
            return CultureList().Where(p => p.Name == name).ToList().FirstOrDefault().Name;
        }
        private List<Culture> CultureList()
        {
            var requestCulture = _contextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            var cultureList = _localizationOptions.SupportedCultures
                    .Select(culture => new Culture
                    {
                        Name = culture.Name,
                        Text = culture.DisplayName
                    }).ToList();
            return cultureList;
        }
    }
}
