using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Storage
{
    public interface IStorage
    {

        Task<(IFormFile file, string fullpath)> UploadAsync(string path, IFormFileCollection formfilecollection);

        Task DeleteAsync(string path,IFormFile formFile);

        Task<List<string>> GetFiles(string path);

        bool HasFile(string path, IFormFile formFile);


    }
}
