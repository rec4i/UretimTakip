using Business.Abstract.Services;
using ClosedXML.Excel;
using Entities.Concrete.VmDtos.ExportedFileDtos;
using Microsoft.AspNetCore.Identity;
using System.Linq.Dynamic.Core;
namespace WebIU.Extensions
{
    public static class ExportFileExtension
    {
        public async static Task<AddExportedFileDto> ExportToExel<T>(List<T> _data, List<string> headers,string UserId,int FileId) where T : class
        {
            string guid = Guid.NewGuid().ToString();
            string fileName = @"wwwroot\\exportedfiles\\"+ guid + ".xlsx";
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

                using (FileStream memoryStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    workbook.SaveAs(memoryStream);
                }

            }


           
            AddExportedFileDto addExportedFileDto = new AddExportedFileDto()
            {
                Id=FileId,
                AddedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                FileName = guid+ ".xlsx",
                AddedUserId = UserId,
                FilePath = fileName.Replace(@"wwwroot\\", ""),
                UserId = UserId,    
                Status=true,
            };


            return addExportedFileDto;


        }
    }
}
