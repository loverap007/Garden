using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    public class LibraryController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll(string category) 
        {


            return View();
        }
    }
}
