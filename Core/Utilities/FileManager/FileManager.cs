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
        public static string Create(IHostEnvironment hostEnvironment, IFormFile formFile)
        {
            List<string> fileTypes = new List<string> { ".jpg", ".png" };

            UploadFile uploadFile = new UploadFile();

            var fileType = Path.GetExtension(formFile.FileName);

            var result = fileTypes.Contains(fileType);

            string filePath = null;

            string parentSaveDirectory = @"wwwroot\";

            string childSaveDirectory = @"uploads\";

            string saveDirectory = parentSaveDirectory + childSaveDirectory;

            string fileName = null;

            if (result)
            {
                uploadFile.FileType = fileType;

                filePath = hostEnvironment.ContentRootPath;

                uploadFile.Id = Guid.NewGuid();

                fileName = uploadFile.Id.ToString() + uploadFile.FileType;

                uploadFile.FileUrl = Path.Combine(filePath, saveDirectory, fileName);

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
    }
}
