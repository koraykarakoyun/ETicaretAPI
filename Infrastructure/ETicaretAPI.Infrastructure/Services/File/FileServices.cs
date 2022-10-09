using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Infrastructure.Operations;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using IOFile = System.IO.File;

namespace ETicaretAPI.Infrastructure.Services.File
{
    public class FileServices : IFileServices
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<(IFormFile file, string fullpath)> UploadAsync(string path, IFormFileCollection formfilecollection)
        {
            string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }
            foreach (IFormFile file in formfilecollection)
            {
                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png" && file.ContentType != "application/pdf")
                {
                    throw new Exception();
                }

                string newfilename = await FileRenameAsync(uploadpath, file.FileName);

                string fullpath = Path.Combine(uploadpath, newfilename);

                 IFormFile uploadedfile = await CopyFileAsync(file, fullpath);

                return (file:uploadedfile,fullpath:Path.Combine(path,newfilename));

            }

            throw new Exception();
          

        }


        private async Task<string> FileRenameAsync(string path, string fileName)
        {
            return await Task.Run<string>(() =>
            {
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
                bool fileIsExists = false;
                int fileIndex = 0;
                do
                {
                    if (IOFile.Exists($"{path}\\{newFileName}"))
                    {
                        fileIsExists = true;
                        fileIndex++;
                        newFileName = $"{NameOperation.CharacterRegulatory(oldName + "-" + fileIndex)}{extension}";
                    }
                    else
                    {
                        fileIsExists = false;
                    }
                } while (fileIsExists);

                return newFileName;
            });

        }

        public async Task<IFormFile> CopyFileAsync(IFormFile file, string fullpath)
        {
            using (FileStream fileStream = new(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false))
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return file;
        }

    }
}
