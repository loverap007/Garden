using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Garden.Data;
using System.Linq;

namespace Garden.Controllers
{
    public class LibraryController : Controller
    {
        int plantPerLoadCount = 12;
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
                .Take(plantPerLoadCount)
                .ToList();
            return View("Index", plants);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult WithFilters(string category)
        {
            return null;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult LoadMore(string category, int count)
        {
            var plants = _db.Plants
                .Where(plant => plant.PlantType.Name == category)
                .Skip(count)
                .Take(plantPerLoadCount)
                .ToArray();
            return Json(plants);
        }
    }
}
