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

        Task<bool> UploadAsync(string path, IFormFileCollection formfilecollection);

        Task<string> FileRenameAsync(string filename);

        Task<bool> CopyFileAsync(IFormFile file,string fullpath);

    }
}
