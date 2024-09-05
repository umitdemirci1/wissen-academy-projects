using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IdentityManagement.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager {  get; set; }

        public RoleController(RoleManager<IdentityRole> _roleManager, UserManager<AppUser> _userManager)
        {
            this.roleManager = _roleManager;
            this.userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index", "Role");
                else
                    Errors(result);
            }
            return View((object)name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role =await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Role");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "Role Not Found");

            return View("Index",roleManager.Roles);
        }

        public  async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();

            foreach (var user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user,role.Name) ? members : nonMembers;
                list.Add(user);
            }

            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if(ModelState.IsValid)
            {
                foreach (string  userId in model.AddIds ?? new string[] {})
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    if (user != null) 
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }

                foreach (string userId in model.DeletedIds ?? new string[] { })
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index), "Role");
            else
                return await Update(model.RoleId);
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
