using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ALoginViewModel.Models.ViewModels; 

namespace AccountController.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            { 
                if (model.UserName != null && model.Password != null) // Verifie pour valeur null 
                { // verifie que PasswordSignInAsync method recoit les valeurs non-null.
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        // Rediriger vers home ou un un resource proteger si le login a reussi.
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
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
