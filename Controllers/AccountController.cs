using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging; // Add this namespace
using ALoginViewModel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AccountController.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger; // Add this field

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
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
                if (!string.IsNullOrWhiteSpace(model.UserName) && !string.IsNullOrWhiteSpace(model.Password))
                {
                    IdentityUser? user = await _signInManager.UserManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            _logger.LogInformation("User logged in.");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "User not found."); // Handle the case when the user is not found.
                    }
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
