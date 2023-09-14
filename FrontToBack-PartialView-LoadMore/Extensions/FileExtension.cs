using FrontToBack_PartialView_LoadMore.ViewModels.AdminSlider;
using Microsoft.AspNetCore.Hosting;

namespace FrontToBack_PartialView_LoadMore.Extensions
{
    public static class FileExtension
    {
        //CheckImage
        public static bool CheckImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        //CheckImage
        public static bool CheckSize(this IFormFile file,double size)
        {
            return file.Length/1024>size;
        }
        //SaveImage
        public static string SaveImage(this IFormFile file,string folder,IWebHostEnvironment webHostEnvironment)
        {
            string fileName = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath, folder, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
                    return fileName;
        }
    }
}
