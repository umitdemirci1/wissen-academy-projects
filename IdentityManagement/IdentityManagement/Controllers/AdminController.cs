using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace IdentityManagement.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;    
        private IPasswordValidator<AppUser> passwordValidator;
        private IUserValidator<AppUser> userValidator;

        public AdminController(UserManager<AppUser> _userManager, IPasswordHasher<AppUser> _passwordHasher, IPasswordValidator<AppUser> _passwordValidator, IUserValidator<AppUser> _userValidator)
        {
            this.userManager = _userManager;
            this.passwordHasher = _passwordHasher;
            this.passwordValidator = _passwordValidator;
            this.userValidator = _userValidator;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = user.Name,
                    Email = user.Email,
                    Country = user.Country,
                    Age = user.Age,
                    Salary = user.Salary
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                if(result.Succeeded) 
                    return RedirectToAction("Index", "Admin");
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("Create_User_Error", $"{error.Code} - {error.Description}");
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            AppUser user =await userManager.FindByIdAsync(id);

            if (user != null)
                return View(user);

            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password,int age, string country,string salary)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("Update_User_Error", "Email cannot be empty");



                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager,user,password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("Update_User_PasswordHash_Error", "Password connot be empty");

                user.Age = age;

                Country updateCountry;
                Enum.TryParse(country, out updateCountry);
                user.Country = updateCountry;

                if (!string.IsNullOrEmpty(salary))
                    user.Salary = salary;
                else
                    ModelState.AddModelError("", "Salary can not be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(salary) && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Admin");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("Update_User_Error", "User Not Found");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Admin");
                else Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return View("Index", userManager.Users);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", $"{error.Code} - {error.Description}");
            }
        }
    }
}
