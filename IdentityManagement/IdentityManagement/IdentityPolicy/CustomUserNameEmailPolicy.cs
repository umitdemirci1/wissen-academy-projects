using IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityManagement.IdentityPolicy
{
    public class CustomUserNameEmailPolicy :UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            IdentityResult result =await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if(user.UserName == "google" || user.UserName == "admin" || user.UserName == "admin123")
            {
                errors.Add(new IdentityError
                {
                    Description = "Username cannot be google, admin or admin123"
                });
            }

            if(!user.Email.ToLower().EndsWith("@contoso.com"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Only contoso.com email addresses are allowed"
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
