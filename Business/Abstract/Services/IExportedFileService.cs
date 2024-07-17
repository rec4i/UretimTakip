using Entities.Concrete.VmDtos.AnnouncementDtos;
using Entities.Concrete.VmDtos.ExportedFileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IExportedFileService
    {
        Task<AddExportedFileDto> Add(AddExportedFileDto entity);
        void Update(AddExportedFileDto entity);
        List<ListExportedFileDto> GetUserFiles(string userId);
    }
}
