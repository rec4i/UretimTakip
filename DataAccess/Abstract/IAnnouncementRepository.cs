using Core.DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.AnnouncementDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace DataAccess.Abstract
{
    public interface IAnnouncementRepository : IEntityRepositoryBase<Announcement>
    {

        Announcement GetFull(Expression<Func<Announcement, bool>> expression);


        List<Announcement> GetWithPagination(FilterQueryStringModel filterQueryStringModel);

        List<Announcement> GetWithPagination(FilterQueryStringModel filterQueryStringModel, List<int> filteredIds);



        int GetWithPaginationCount(FilterQueryStringModel filterQueryStringModel);

        int GetWithPaginationcCount(FilterQueryStringModel filterQueryStringModel, List<int> filteredIds);


    }
}
