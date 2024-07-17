using Business.Concrete.Services;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IContactService
    {
        Contact GetById(int id);
        List<Contact> GetAll();
        int GetCount();
        void Delete(Contact entity);
        void Add(Contact entity);
    }
}
