using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Business.Concrete.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository ContactRepository)
        {
            _contactRepository =ContactRepository;
        }
        public void Add(Contact entity)
        {
            _contactRepository.Add(entity);
        }
        public void Delete(Contact entity)
        {
            _contactRepository.Delete(entity);
        }
        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll(p => p.IsDeleted == false).OrderByDescending(p=>p.AddedDate).ToList();
        }
        public Contact GetById(int id)
        {
            return _contactRepository.Get(p => p.Id == id);
        }

        public int GetCount()
        {
            return _contactRepository.GetAll(p => p.IsDeleted == false).Count();
        }
    }

}
