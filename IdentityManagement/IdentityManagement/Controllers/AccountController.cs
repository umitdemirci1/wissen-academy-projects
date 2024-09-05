using IdentityManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);

                if (appUser != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, login.RememberMe, false);

                    if (result.Succeeded)
                    {
                        string returnUrl = login.ReturnUrl ?? "";
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            string[] returnUrlArray = returnUrl.Split('/');
                            return RedirectToAction(returnUrlArray[2], returnUrlArray[1]);
                        }
                        //return RedirectToAction(login.ReturnUrl ?? "/");
                    }

                    ModelState.AddModelError(nameof(login.Email), "Login Failed : Invalid Email or password");
                }

            }
            return View(login);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
