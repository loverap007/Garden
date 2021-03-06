﻿using Garden.Data;
using Garden.Models;
using Garden.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            user.SecurityStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin) await _userManager.RemoveFromRoleAsync(user, "Admin");
            else await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Companies()
        {
            var companies = _db.Companies.OrderBy(company => company.Confirmed).ToList();
            return View(companies);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _db.Companies.FindAsync(id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
            return RedirectToAction(nameof(Companies));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmCompany(int id)
        {
            var company = await _db.Companies.FindAsync(id);
            var owner = _db.Users.FindAsync(company.UserId);
            company.Confirmed = true;
            _db.Companies.Update(company);
            var manageUrl = Url.Action(
                "CompaniesManagment",
                "Manage",
                new { });
            await _emailSender.SendEmailAsync((await owner).Email, "Подтверждение",
                $"Ваша компания прошла модерацию. Просматривать и управлять своими компаниями можно на <a href='{manageUrl}'>этой</a> странице.");
            _db.SaveChanges();
            return RedirectToAction(nameof(Companies));
        }

        [HttpGet]
        public IActionResult Categories()
        {
            ViewBag.Categories = _db.PlantTypes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            var plantType = new PlantType()
            {
                Name = model.Title
            };
            _db.PlantTypes.Add(plantType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _db.PlantTypes.FindAsync(id);
            _db.PlantTypes.Remove(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public IActionResult AddPlant()
        {
            ViewBag.Categories = _db.PlantTypes.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlant(AddPlantViewModel model)
        {
            var plant = new Plant
            {
                Title = model.Name,
                Description = model.Description,
                PlantTypeId = model.Type
            };
            var plantId = _db.Plants.Add(plant).Entity.Id;
            foreach(var photo in Request.Form.Files)
            {
                var plantPhoto = new PlantPhoto
                {
                    PlantId = plantId,
                    PathToPhoto = await _fileKeeper.KeepFileAsync("/images/PlantPhotos/", photo.FileName, photo)
                };
                _db.Photos.Add(plantPhoto);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(AddPlant));
        }
    }
}
