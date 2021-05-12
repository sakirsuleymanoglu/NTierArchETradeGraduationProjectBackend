using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Core.Utilities.FileManager;

namespace Core.Utilities.UploadFiles
{
    public class FileManager
    {
        static string parentSaveDirectory = @"wwwroot\";
        static string childSaveDirectory = @"uploads\";

        public static string Create(IHostEnvironment hostEnvironment, IFormFile formFile)
        {
            List<string> fileTypes = new List<string> { ".jpg", ".png" };

            UploadFile uploadFile = new UploadFile();

            var fileType = Path.GetExtension(formFile.FileName);

            var result = fileTypes.Contains(fileType);

            string rootPath = null;

            string saveDirectory = parentSaveDirectory + childSaveDirectory;

            string fileName = null;

            if (result)
            {
                uploadFile.FileType = fileType;

                rootPath = hostEnvironment.ContentRootPath;

                uploadFile.Id = Guid.NewGuid();

                fileName = uploadFile.Id.ToString() + uploadFile.FileType;

                uploadFile.FileUrl = Path.Combine(rootPath, saveDirectory, fileName);

                using (var stream = new FileStream(uploadFile.FileUrl, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            else
            {
                throw new Exception("Dosya tipi gerçersizdir");
            }

            return childSaveDirectory + fileName;
        }

        public static void Delete(IHostEnvironment hostEnvironment, string imagePath)
        {
            string rootPath = hostEnvironment.ContentRootPath;

            string fullPath = Path.Combine(rootPath, parentSaveDirectory, imagePath);

            File.Delete(fullPath);
        }
    }
}
