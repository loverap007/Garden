using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Garden.Services
{
    interface IFileKeeper
    {
        Task<string> KeepFileAsync(string path, string filename, IFormFile file);
    }
}
