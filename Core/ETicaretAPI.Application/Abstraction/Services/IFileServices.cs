using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Services
{
    public interface IFileServices
    {

        Task<(IFormFile file, string fullpath)> UploadAsync(string path, IFormFileCollection formfilecollection);

        Task<IFormFile> CopyFileAsync(IFormFile file,string fullpath);

    }
}
