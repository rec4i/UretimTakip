using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace Tools.Concrete.HelperTools.BusinessHelpers
{
    public static class PhotoHelper
    {
        public static async Task<string> UpdatePhoto(IFormFile file, string savePath)
        {
            if (!file.ContentType.Contains("image"))
                return "";

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{savePath}"));
            var fullPath = Path.Combine(path, fileName);
            int width = 400;
            int height = 400;
            Image image = Image.FromStream(file.OpenReadStream(), true, true);
            var newImage = new Bitmap(width,height);
            using (var g=Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, width, height);
                newImage.Save(fullPath);
            }
            return fileName;
        }
        public static void DeletePhoto(string imageName, string savePath)
        {
            try
            {
                if (imageName!="DefaultImage.png")
                {
                    System.IO.File.Delete($"wwwroot/images/{savePath}/{imageName}");
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
