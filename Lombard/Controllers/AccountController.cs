using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lombard.DAL;
using Lombard.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lombard.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;


        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]AuthModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (!result.Succeeded)
                return LocalRedirect("Login");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]AuthModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User user = new User() { UserName = model.Login };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest();

            await signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
    }
}