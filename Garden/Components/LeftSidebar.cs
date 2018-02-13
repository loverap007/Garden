using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Garden.Data;

namespace Garden.Components
{
    public class LeftSidebar : ViewComponent
    {
        private ApplicationDbContext _db;

        public LeftSidebar(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var plantTypesNames = _db.PlantTypes.Select(x => x.Name).ToList();
            return View("LeftSidebar", plantTypesNames);
        }
    }
}
