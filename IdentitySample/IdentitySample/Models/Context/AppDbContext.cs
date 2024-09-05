using IdentitySample.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.Models.Context
{
    /*
     * Identity tablolarına CRUD işlemleri yapabilmek için kullanılacak olan sınıflar:
     * 1 - UserManager - User işlemleri için kullanılır.
     * 2 - RoleManager - Role işlemleri için kullanılır.
     * 3 - SignInManager - Login LogOut işlemlerini yönetmek için kullanılır.
     * 12:56 29-07
     * DbSet yerine gelmiş gibi düşünülebilir.
     * 
     */

    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
