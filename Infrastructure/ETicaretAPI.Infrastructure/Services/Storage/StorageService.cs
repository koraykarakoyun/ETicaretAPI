using ETicaretAPI.Application.Abstraction.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task DeleteAsync(string path, IFormFile formFile)
        {
            await _storage.DeleteAsync(path, formFile);
        }

        public Task<List<string>> GetFiles(string path)
        {
            return _storage.GetFiles(path);
        }

        public bool HasFile(string path, IFormFile formFile)
        {
            return _storage.HasFile(path, formFile);
        }

        public Task<(IFormFile file, string fullpath)> UploadAsync(string path, IFormFileCollection formfilecollection)
        {
            return _storage.UploadAsync(path, formfilecollection);
        }
    }
}
