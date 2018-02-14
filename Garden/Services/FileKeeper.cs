using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Garden.Services
{
    public class FileKeeper : IFileKeeper
    {
        IHostingEnvironment _appEnvironment;

        public FileKeeper(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<string> KeepFileAsync(string path, string filename, IFormFile file)
        {
            var fullPath = path + "/" + filename;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fullPath;
        }
    }
}
