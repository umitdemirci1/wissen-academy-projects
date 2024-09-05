using Microsoft.AspNetCore.Identity;

namespace IdentitySample.Models.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }
    }
}
