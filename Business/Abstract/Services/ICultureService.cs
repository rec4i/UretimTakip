using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface ICultureService
    {
        List<Culture> GetAll();
        string GetCultureName(string name);
        Culture GetCulture(string name);
    }
}
