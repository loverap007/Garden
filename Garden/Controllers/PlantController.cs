using Garden.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Garden.Models;
using System.Linq;

namespace Garden.Controllers
{
    public class PlantController : Controller
    {
        private ApplicationDbContext _db;

        public PlantController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPlant(int id)
        {
            var plantFull = new PlantViewModel();
            var plant = _db.Plants.Find(id);
            if (plant == null) return NotFound();
            plantFull.Plant = plant;
            plantFull.PlantPhotos = _db.Photos.Where(photo => photo.PlantId == id).ToList();
            plantFull.Parameters = _db.Parameters.Where(parameter => parameter.PlantId == id).ToList();
            plantFull.Offers = _db.Offers.Where(offer => offer.PlantId == id && offer.Company.Confirmed).OrderByDescending(offer => offer.Created).ToList();
            foreach(var offer in plantFull.Offers)
            {
                offer.Company = _db.Companies.Where(company => company.Id == offer.CompanyId).First();
            }
            ViewBag.Title = plant.Title;
            return View("Index", plantFull);
        }
    }
}
