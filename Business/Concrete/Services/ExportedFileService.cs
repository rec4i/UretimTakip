using AutoMapper;
using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.AnnouncementDtos;
using Entities.Concrete.VmDtos.ExportedFileDtos;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class ExportedFileService : IExportedFileService
    {
        private readonly IExportedFileRepository _exportedFileRepository;
        private readonly IMapper _mapper;
        public ExportedFileService(IExportedFileRepository exportedFileRepository, IMapper mapper)
        {
            _exportedFileRepository = exportedFileRepository;
            _mapper = mapper;
        }

        public async Task<AddExportedFileDto> Add(AddExportedFileDto entity)
        {
            var _entity = _mapper.Map<ExportedFile>(entity);
            var retrunedEnttiy=  _exportedFileRepository.AddAsnyc(_entity).Result;
            return _mapper.Map<AddExportedFileDto>(retrunedEnttiy);
        }

        public List<ListExportedFileDto> GetUserFiles(string userId)
        {
            var files = _exportedFileRepository.GetAll(o => o.UserId == userId);
            return _mapper.Map<List<ListExportedFileDto>>(files).AsEnumerable().OrderByDescending(o => o.Id).ToList();
        }

        public void Update(AddExportedFileDto entity)
        {
            
            var file = _exportedFileRepository.Get(o => o.Id == entity.Id);
            file.FilePath=entity.FilePath;
            file.FileName = entity.FileName;
            file.Status = true;
            _exportedFileRepository.Update(file);
        }
    }
}
