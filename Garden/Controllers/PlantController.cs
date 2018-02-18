using Garden.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Garden.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Garden.Controllers
{
    public class PlantController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public PlantController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager
            )
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlant(int id)
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
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.UserCompaniesCount = _db.Companies.Where(company => company.UserId == user.Id).Count();
            }
            return View("Index", plantFull);
        }
    }
}
