using ETicaretAPI.Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.File
{
    public class FileServices : IFileServices
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<bool> UploadAsync(string path, IFormFileCollection formfilecollection)
        {
            string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }


            foreach (IFormFile file in formfilecollection)
            {


                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                {
                    throw new Exception();
                }

                string newfilename = await FileRenameAsync(file.FileName);

             


                string fullpath = Path.Combine(uploadpath, newfilename);
                bool result = await CopyFileAsync(file, fullpath);

                if (!result)
                {
                    throw new Exception();
                }
            }

            return true;


        }


        public async Task<string> FileRenameAsync(string filename)
        {
            return filename;
        }

        public async Task<bool> CopyFileAsync(IFormFile file, string fullpath)
        {
            using (FileStream fileStream = new(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false))
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

            }
            return true;

        }
    }
}
