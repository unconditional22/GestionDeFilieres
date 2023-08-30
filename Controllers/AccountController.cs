using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging; // Add this namespace

using ALoginViewModel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AccountController.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger; // Add this field

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger) // Add ILogger parameter
        {
            _signInManager = signInManager;
            _logger = logger; // Initialize the logger
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName != null && model.Password != null) // Add null checks here
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username and password are required.");
                }
            }
            return View(model);
        }

    }
}
