using Entities.Concrete.VmDtos.AnnouncementDtos;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace Business.Abstract.Services
{
    public interface IAnnouncementService
    {
        void Add(AddAnnouncementDto entity);
        void Remove(RemoveAnnouncementDto entity);
        void Update(UpdateAnnouncementDto entity);

        ListAnnouncementDto Get(int Id);

        List<ListAnnouncementDto> GetAll();
        List<ListAnnouncementDto> GetAll(FilterQueryStringModel filterQueryStringModel);

        int GellAllCount();
        int GellAllCount(FilterQueryStringModel filterQueryStringModel);


        List<ListAnnouncementDto> GetUserAnnouncments(string UserId = null);
        List<ListAnnouncementDto> GetUserAnnouncments(FilterQueryStringModel filterQueryStringModel, string UserId = null);

        int GetUserAnnouncmentsCount(string UserId = null);
        int GetUserAnnouncmentsCount(FilterQueryStringModel filterQueryStringModel, string UserId = null);






    }
}
