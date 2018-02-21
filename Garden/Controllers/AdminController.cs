using Garden.Data;
using Garden.Models;
using Garden.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IFileKeeper _fileKeeper;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private ApplicationDbContext _db;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IFileKeeper fileKeeper,
            IEmailSender emailSender,
            ApplicationDbContext db,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _fileKeeper = fileKeeper;
            _emailSender = emailSender;
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = new List<UserViewModel>();
            foreach(var user in _db.Users.ToList())
            {
                var viewUser = new UserViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Admin = await _userManager.IsInRoleAsync(user, "Admin")
                };
                users.Add(viewUser);
            }
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if ((await _userManager.GetUserAsync(User)).Id == id)
            {
                return Content("Не стоит удалять самого себя, обратитесь к другому администратору");
            }
            var user = _db.Users.First(usr => usr.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangeRole(string id)
        {
            var user = _db.Users.First(usr => usr.Id == id);
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin) await _userManager.RemoveFromRoleAsync(user, "Admin");
            else await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }
    }
}
