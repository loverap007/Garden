using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Garden.Data;
using System.Linq;

namespace Garden.Controllers
{
    public class LibraryController : Controller
    {
        ApplicationDbContext _db;

        public LibraryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFirst(string category) 
        {
            ViewBag.Category = category;
            var plants = _db.Plants
                .Where(plant => plant.PlantType.Name == category)
                .Take(12)
                .ToList();
            return View("Index", plants);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult WithFilters()
        {
            return null;
        }
    }
}
