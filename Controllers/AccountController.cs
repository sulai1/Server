using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public UserManager<AppUser> UserManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
            UserManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.PasswordRetype)
                {
                    ModelState.AddModelError(string.Empty, "Password not Matching");
                }
                else
                {
                    AppUser user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                    var created = await UserManager.CreateAsync(user, model.Password);
                    if (!created.Succeeded)
                    {
                        foreach(var error in created.Errors)
                            ModelState.AddModelError(error.Code, error.Description);
                    }
                    else
                    {
                        var result = await signInManager.PasswordSignInAsync(
                            model.Email, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "home");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }

            return View(model);
        }
    }
}
