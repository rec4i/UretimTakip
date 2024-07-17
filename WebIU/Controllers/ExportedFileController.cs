using Business.Abstract.Services;
using ClosedXML.Excel;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.ExportedFileDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
namespace WebIU.Controllers
{
    public class ExportedFileController : Controller
    {
        private readonly IExportedFileService _exportedFileService;
        private readonly UserManager<AppIdentityUser> _userManager;
        public ExportedFileController(IExportedFileService exportedFileService,UserManager<AppIdentityUser> userManager)
        {
            _exportedFileService =exportedFileService;
            _userManager = userManager;
        }

        public IActionResult AllExportedFiles()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var model = _exportedFileService.GetUserFiles(userId);

            return View(model);
        }
        public async Task<AddExportedFileDto> ExportToExel<T>(List<T> _data, List<string> headers, string UserId) where T : class
        {
            string guid = Guid.NewGuid().ToString();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Page 1");
                int headerCounter = 0;
                foreach (var header in headers)
                {
                    worksheet.Cell(1, headerCounter + 1).SetValue(header);
                    headerCounter++;
                }
                worksheet.Row(1).CellsUsed().Style.Font.SetBold();
                worksheet.Row(1).CellsUsed().Style.Font.SetFontSize(12);
                worksheet.Row(1).CellsUsed().Style.Fill.SetBackgroundColor(XLColor.LightGray);

                var projects = _data as List<T>;


                string headersString = "";
                for (int i = 0; i < headerCounter; i++)
                {
                    headersString += headers[i] + ",";
                }
                headersString = headersString.Trim(',');

                var data = projects.AsQueryable().Select("new {" + headersString + "}").AsEnumerable().ToList();

                for (int i = 0; i < data.Count(); i++)
                {
                    for (int j = 0; j < headerCounter; j++)
                    {
                        var nameOfProperty = headers[j];
                        var propertyInfo = data[i].GetType().GetProperty(nameOfProperty);
                        var value = propertyInfo.GetValue(data[i], null);
                        worksheet.Cell((i + 2), (j + 1)).Value = value;
                    }
                }

                using (FileStream memoryStream = new FileStream(guid + ".xlsx", FileMode.OpenOrCreate))
                {
                    workbook.SaveAs(memoryStream);
                }

            }


            string fileName = guid + ".xlsx";
            AddExportedFileDto addExportedFileDto = new AddExportedFileDto()
            {
                AddedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                FileName = fileName,
                AddedUserId = UserId,
                FilePath = fileName,
                UserId = UserId,
            };


            return addExportedFileDto;
        }
    }
}
