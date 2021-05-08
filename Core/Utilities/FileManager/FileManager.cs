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

            if (result)
            {
                uploadFile.FileType = fileType;

                var filePath = hostEnvironment.ContentRootPath;

                var fileName = Path.GetFileName(formFile.FileName);

                if (formFile.Length > 0)
                {
                    uploadFile.Id = Guid.NewGuid();

                    uploadFile.FileName = fileName;

                    uploadFile.FileUrl = Path.Combine(filePath, @"wwwroot\uploads", uploadFile.Id.ToString() + uploadFile.FileType);

                    using (var stream = new FileStream(uploadFile.FileUrl, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
            }

            return uploadFile.FileUrl;
        }
    }
}
