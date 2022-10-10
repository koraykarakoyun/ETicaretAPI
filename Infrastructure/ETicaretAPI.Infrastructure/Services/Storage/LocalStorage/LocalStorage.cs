using ETicaretAPI.Application.Abstraction.Storage.LocalStorage;
using ETicaretAPI.Domain.Entities.File;
using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOFile = System.IO.File;

namespace ETicaretAPI.Infrastructure.Services.Storage.LocalStorage
{
    public class LocalStorage : ILocalStorage
    {

        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, IFormFile formFile)
        {
            IOFile.Delete(Path.Combine(path, formFile.FileName));
        }

        public async Task<List<string>> GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new(path);

            return directoryInfo.GetFiles().Select(f => f.Name).ToList();

        }

        public bool HasFile(string path, IFormFile formFile)
        {
            return IOFile.Exists(Path.Combine(path, formFile.FileName));
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

                return (file: uploadedfile, fullpath: Path.Combine(path, newfilename));

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

        private async Task<IFormFile> CopyFileAsync(IFormFile file, string fullpath)
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
