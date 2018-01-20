using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Models.Identity;
using PortfolioSite.Data;
using PortfolioSite.ViewModels.Account;

namespace PortfolioSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [Route("/admin")]
        public IActionResult Index()
        {
            List<ApplicationUser> model = _db.Users.ToList();
            return View(model);
        }

        [Route("/admin/loginform")]
        public IActionResult LoginForm()
        {
            return PartialView("_LoginForm");
        }

        [Route("/admin/registerform")]
        public IActionResult RegisterForm()
        {
            return PartialView("_RegisterForm");
        }

        [HttpPost, Route("/admin/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, Route("/admin/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var newUser = new ApplicationUser {
                UserName = model.Email,
                Email = model.Email
            };
            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string userId)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var result = await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
